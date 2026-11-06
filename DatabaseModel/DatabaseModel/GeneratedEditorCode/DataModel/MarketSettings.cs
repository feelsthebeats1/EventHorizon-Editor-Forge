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
	public partial class MarketSettings
	{
		partial void OnDataDeserialized(MarketSettingsSerializable serializable, Database database);
		partial void OnDataSerialized(ref MarketSettingsSerializable serializable);

		public static MarketSettings Create(MarketSettingsSerializable serializable, Database database)
		{
			if (serializable == null) return DefaultValue;
			return new MarketSettings(serializable, database);
		}

		private MarketSettings(MarketSettingsSerializable serializable, Database database)
		{
			FuelRenewal = new NumericValue<float>(serializable.FuelRenewal, -1f, 1000000f);
			TechRenewal = new NumericValue<float>(serializable.TechRenewal, -1f, 1000000f);
			StarsRenewal = new NumericValue<float>(serializable.StarsRenewal, -1f, 1000000f);
			ShipRenewal = new NumericValue<float>(serializable.ShipRenewal, -1f, 1000000f);
			CommonComponentRenewal = new NumericValue<float>(serializable.CommonComponentRenewal, -1f, 1000000f);
			RareComponentRenewal = new NumericValue<float>(serializable.RareComponentRenewal, -1f, 1000000f);
			SatelliteRenewal = new NumericValue<float>(serializable.SatelliteRenewal, -1f, 1000000f);
			RareComponentLevel = serializable.RareComponentLevel;
			RareComponentMin = new NumericValue<int>(serializable.RareComponentMin, 0, 20);
			RareComponentMax = new NumericValue<int>(serializable.RareComponentMax, 0, 20);
			SatelliteCount = new NumericValue<int>(serializable.SatelliteCount, 0, 20);
			BlackMarketMoney = new NumericValue<int>(serializable.BlackMarketMoney, 0, 1000000);
			OnDataDeserialized(serializable, database);
		}

		public void Save(MarketSettingsSerializable serializable)
		{
			serializable.FuelRenewal = FuelRenewal.Value;
			serializable.TechRenewal = TechRenewal.Value;
			serializable.StarsRenewal = StarsRenewal.Value;
			serializable.ShipRenewal = ShipRenewal.Value;
			serializable.CommonComponentRenewal = CommonComponentRenewal.Value;
			serializable.RareComponentRenewal = RareComponentRenewal.Value;
			serializable.SatelliteRenewal = SatelliteRenewal.Value;
			serializable.RareComponentLevel = RareComponentLevel;
			serializable.RareComponentMin = RareComponentMin.Value;
			serializable.RareComponentMax = RareComponentMax.Value;
			serializable.SatelliteCount = SatelliteCount.Value;
			serializable.BlackMarketMoney = BlackMarketMoney.Value;
			OnDataSerialized(ref serializable);
		}

		[TooltipText("Minutes before a market refills its fuel stock. A negative value never refills.")]
		public NumericValue<float> FuelRenewal = new NumericValue<float>(0, -1f, 1000000f);
		[TooltipText("Minutes before the black market refills its research stock.")]
		public NumericValue<float> TechRenewal = new NumericValue<float>(0, -1f, 1000000f);
		[TooltipText("Minutes before the black market refills its star stock.")]
		public NumericValue<float> StarsRenewal = new NumericValue<float>(0, -1f, 1000000f);
		[TooltipText("Minutes before a market refills its ship stock. The built-in value never refills.")]
		public NumericValue<float> ShipRenewal = new NumericValue<float>(0, -1f, 1000000f);
		[TooltipText("Minutes before a faction market refills one common component.")]
		public NumericValue<float> CommonComponentRenewal = new NumericValue<float>(0, -1f, 1000000f);
		[TooltipText("Minutes before the black market refills one rare component.")]
		public NumericValue<float> RareComponentRenewal = new NumericValue<float>(0, -1f, 1000000f);
		[TooltipText("Minutes before the black market refills one satellite.")]
		public NumericValue<float> SatelliteRenewal = new NumericValue<float>(0, -1f, 1000000f);
		[TooltipText("Component level the black market offers at a star level.")]
		public string RareComponentLevel;
		[TooltipText("Smallest number of rare components in a black market.")]
		public NumericValue<int> RareComponentMin = new NumericValue<int>(0, 0, 20);
		[TooltipText("Largest number of rare components in a black market, one below the roll limit.")]
		public NumericValue<int> RareComponentMax = new NumericValue<int>(0, 0, 20);
		[TooltipText("Number of satellites in a black market. The Master Trader skill adds one more.")]
		public NumericValue<int> SatelliteCount = new NumericValue<int>(0, 0, 20);
		[TooltipText("Credits the black market accepts per visit.")]
		public NumericValue<int> BlackMarketMoney = new NumericValue<int>(0, 0, 1000000);

		public static MarketSettings DefaultValue { get; private set; }
	}
}
