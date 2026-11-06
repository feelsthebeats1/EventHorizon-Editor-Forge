using System;
using DatabaseMigration.v1.Enums;
using DatabaseMigration.v1.Serializable;

namespace DatabaseMigration.v1
{
	public partial class DatabaseUpgrader
	{
		partial void Migrate_7_8()
		{
			Console.WriteLine("Database migration: v1.7 -> v1.8");

			// Version 1.7 hid Titan satellites with a code rule. The rule becomes two
			// flags on each record, so a mod never needs to read the built-in catalog.
			foreach (var satellite in Content.SatelliteList)
			{
				if (satellite.SizeClass != SizeClass.Titan) continue;

				satellite.NotAvailableInBlackMarket = true;
				satellite.NotAvailableInRuin = true;
			}
		}
	}
}
