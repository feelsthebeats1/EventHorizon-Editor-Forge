//-------------------------------------------------------------------------------
//                                                                               
//    This code was automatically generated.                                     
//    Changes to this file may cause incorrect behavior and will be lost if      
//    the code is regenerated.                                                   
//                                                                               
//-------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using EditorDatabase.Enums;
using EditorDatabase.Model;

namespace EditorDatabase.Serializable
{
	[Serializable]
	public class RuinsSettingsSerializable : SerializableItem
	{
		[DefaultValue("MAX(6, FLOOR(level/2))")]
		public string MaxSatelliteCells = "MAX(6, FLOOR(level/2))";
		[DefaultValue(5)]
		public int CreditsMultiplier = 5;
		[DefaultValue(5)]
		public int FuelMin = 5;
		[DefaultValue(14)]
		public int FuelMax = 14;
		[DefaultValue(3)]
		public int SatelliteChance = 3;
		[DefaultValue(1)]
		public int SatelliteCount = 1;
		[DefaultValue("level + 35")]
		public string ComponentLevel = "level + 35";
		[DefaultValue(1)]
		public int ComponentMin = 1;
		[DefaultValue(2)]
		public int ComponentMax = 2;
		[DefaultValue(0)]
		public int StarsMin = 0;
		[DefaultValue(2)]
		public int StarsMax = 2;
		[DefaultValue(2)]
		public int FleetSizeMultiplier = 2;
	}
}
