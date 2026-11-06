//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using EditorDatabase.Model;
using DatabaseMigration.v1.Enums;

namespace DatabaseMigration.v1.Serializable
{
	[Serializable]
	public class MarketSettingsSerializable : SerializableItem
	{
		public MarketSettingsSerializable()
		{
			ItemType = ItemType.MarketSettings;
			FileName = "MarketSettings.json";
		}

		[DefaultValue(1f)]
		public float FuelRenewal = 1f;
		[DefaultValue(60f)]
		public float TechRenewal = 60f;
		[DefaultValue(1440f)]
		public float StarsRenewal = 1440f;
		[DefaultValue(-1f)]
		public float ShipRenewal = -1f;
		[DefaultValue(1440f)]
		public float CommonComponentRenewal = 1440f;
		[DefaultValue(4320f)]
		public float RareComponentRenewal = 4320f;
		[DefaultValue(4320f)]
		public float SatelliteRenewal = 4320f;
		[DefaultValue("level + 75")]
		public string RareComponentLevel = "level + 75";
		[DefaultValue(4)]
		public int RareComponentMin = 4;
		[DefaultValue(7)]
		public int RareComponentMax = 7;
		[DefaultValue(3)]
		public int SatelliteCount = 3;
		[DefaultValue(10000)]
		public int BlackMarketMoney = 10000;
	}
}
