//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System.Linq;
using EditorDatabase.Enums;
using EditorDatabase.Serializable;
using EditorDatabase.Model;

namespace EditorDatabase.DataModel
{
	public partial class RuinsSettings
	{
		partial void OnDataDeserialized(RuinsSettingsSerializable serializable, Database database);
		partial void OnDataSerialized(ref RuinsSettingsSerializable serializable);

		public static RuinsSettings Create(RuinsSettingsSerializable serializable, Database database)
		{
			if (serializable == null) return DefaultValue;
			return new RuinsSettings(serializable, database);
		}

		private RuinsSettings(RuinsSettingsSerializable serializable, Database database)
		{
			MaxSatelliteCells = serializable.MaxSatelliteCells;
			CreditsMultiplier = new NumericValue<int>(serializable.CreditsMultiplier, 0, 100);
			FuelMin = new NumericValue<int>(serializable.FuelMin, 0, 100);
			FuelMax = new NumericValue<int>(serializable.FuelMax, 0, 100);
			SatelliteChance = new NumericValue<int>(serializable.SatelliteChance, 1, 100);
			SatelliteCount = new NumericValue<int>(serializable.SatelliteCount, 0, 10);
			ComponentLevel = serializable.ComponentLevel;
			ComponentMin = new NumericValue<int>(serializable.ComponentMin, 0, 20);
			ComponentMax = new NumericValue<int>(serializable.ComponentMax, 0, 20);
			StarsMin = new NumericValue<int>(serializable.StarsMin, 0, 10);
			StarsMax = new NumericValue<int>(serializable.StarsMax, 0, 10);
			FleetSizeMultiplier = new NumericValue<int>(serializable.FleetSizeMultiplier, 1, 10);
			OnDataDeserialized(serializable, database);
		}

		public void Save(RuinsSettingsSerializable serializable)
		{
			serializable.MaxSatelliteCells = MaxSatelliteCells;
			serializable.CreditsMultiplier = CreditsMultiplier.Value;
			serializable.FuelMin = FuelMin.Value;
			serializable.FuelMax = FuelMax.Value;
			serializable.SatelliteChance = SatelliteChance.Value;
			serializable.SatelliteCount = SatelliteCount.Value;
			serializable.ComponentLevel = ComponentLevel;
			serializable.ComponentMin = ComponentMin.Value;
			serializable.ComponentMax = ComponentMax.Value;
			serializable.StarsMin = StarsMin.Value;
			serializable.StarsMax = StarsMax.Value;
			serializable.FleetSizeMultiplier = FleetSizeMultiplier.Value;
			OnDataSerialized(ref serializable);
		}

		[TooltipText("Largest satellite layout, in cells, that ruins can drop at a star level.")]
		public string MaxSatelliteCells;
		[TooltipText("Credits per ruin, times the distance credit formula.")]
		public NumericValue<int> CreditsMultiplier = new NumericValue<int>(0, 0, 100);
		[TooltipText("Smallest fuel stack a ruin gives.")]
		public NumericValue<int> FuelMin = new NumericValue<int>(0, 0, 100);
		[TooltipText("Largest fuel stack a ruin gives. The value is inclusive.")]
		public NumericValue<int> FuelMax = new NumericValue<int>(0, 0, 100);
		[TooltipText("One in this many ruins drops a satellite.")]
		public NumericValue<int> SatelliteChance = new NumericValue<int>(0, 1, 100);
		[TooltipText("Number of satellites a ruin drops.")]
		public NumericValue<int> SatelliteCount = new NumericValue<int>(0, 0, 10);
		[TooltipText("Component level a ruin gives at a star level.")]
		public string ComponentLevel;
		[TooltipText("Smallest number of components a ruin gives.")]
		public NumericValue<int> ComponentMin = new NumericValue<int>(0, 0, 20);
		[TooltipText("Largest number of components a ruin gives. The value is inclusive.")]
		public NumericValue<int> ComponentMax = new NumericValue<int>(0, 0, 20);
		[TooltipText("Smallest premium star payout. Zero means the ruin pays no stars.")]
		public NumericValue<int> StarsMin = new NumericValue<int>(0, 0, 10);
		[TooltipText("Largest premium star payout. The value is inclusive.")]
		public NumericValue<int> StarsMax = new NumericValue<int>(0, 0, 10);
		[TooltipText("Ruins fleet size, times the common fleet size formula.")]
		public NumericValue<int> FleetSizeMultiplier = new NumericValue<int>(0, 1, 10);

		public static RuinsSettings DefaultValue { get; private set; }
	}
}
