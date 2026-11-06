using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameDatabase
{
    // The first 1.8 builds kept satellite availability in exclusion lists inside two
    // settings records. The flags now live on each Satellite record. A mod that was
    // already upgraded to 1.8 carries the lists, so it needs this one pass to move them.
    public static class SatelliteListConverter
    {
        private const int SatelliteItemType = 7;

        public static string Convert(string folder)
        {
            var market = ReadExclusions(folder, "BlackMarketSettings.json");
            var ruins = ReadExclusions(folder, "RuinsSettings.json");

            var (changed, present) = ApplyFlags(folder, market, ruins);
            var deleted = DeleteFiles(folder, "BlackMarketSettings.json");
            var stripped = StripExclusions(folder, "RuinsSettings.json");

            if (changed == 0 && deleted == 0 && stripped == 0)
                return "Nothing changed: this folder has no satellite exclusion lists.";

            var message = $"Set flags on {changed} satellite record(s), removed {deleted} BlackMarketSettings.json " +
                          $"and cleared ExcludedSatellites in {stripped} RuinsSettings.json.";

            var excluded = new HashSet<int>((market ?? new HashSet<int>()).Concat(ruins ?? new HashSet<int>()));
            var missing = string.Join(", ", excluded.Except(present).OrderBy(item => item));
            if (missing.Length > 0)
                message += $" Satellites {missing} are not in this mod, so add their records here and set the flag to keep them excluded.";

            return message;
        }

        private static HashSet<int> ReadExclusions(string folder, string fileName)
        {
            var file = FindFiles(folder, fileName).FirstOrDefault();
            if (file == null) return null;

            var list = JObject.Parse(File.ReadAllText(file))["ExcludedSatellites"] as JArray;
            return list == null ? new HashSet<int>() : new HashSet<int>(list.Select(item => item.Value<int>()));
        }

        private static (int changed, HashSet<int> present) ApplyFlags(string folder, HashSet<int> market, HashSet<int> ruins)
        {
            var present = new HashSet<int>();
            var changed = 0;

            foreach (var file in Directory.EnumerateFiles(folder, "*.json", SearchOption.AllDirectories))
            {
                var data = JObject.Parse(File.ReadAllText(file));
                if (data.Value<int>("ItemType") != SatelliteItemType) continue;

                var id = data.Value<int>("Id");
                present.Add(id);

                var write = false;
                if (market != null && market.Contains(id) && data.Value<bool?>("NotAvailableInBlackMarket") != true)
                {
                    data["NotAvailableInBlackMarket"] = true;
                    write = true;
                }

                if (ruins != null && ruins.Contains(id) && data.Value<bool?>("NotAvailableInRuin") != true)
                {
                    data["NotAvailableInRuin"] = true;
                    write = true;
                }

                if (!write) continue;

                File.WriteAllText(file, data.ToString(Formatting.Indented));
                changed++;
            }

            return (changed, present);
        }

        private static int DeleteFiles(string folder, string fileName)
        {
            var files = FindFiles(folder, fileName).ToList();
            foreach (var file in files)
                File.Delete(file);

            return files.Count;
        }

        // RuinsSettings stays, because MaxSatelliteCells still lives in it.
        private static int StripExclusions(string folder, string fileName)
        {
            var stripped = 0;
            foreach (var file in FindFiles(folder, fileName).ToList())
            {
                var data = JObject.Parse(File.ReadAllText(file));
                if (data["ExcludedSatellites"] == null) continue;

                data.Remove("ExcludedSatellites");
                File.WriteAllText(file, data.ToString(Formatting.Indented));
                stripped++;
            }

            return stripped;
        }

        private static IEnumerable<string> FindFiles(string folder, string fileName) =>
            Directory.EnumerateFiles(folder, fileName, SearchOption.AllDirectories);
    }
}
