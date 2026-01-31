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
	public class AsteroidBeltSettingsSerializable
	{
		[DefaultValue(70)]
		public int MeteoriteChance = 70;
		[DefaultValue(15)]
		public int ContainerChance = 15;
		[DefaultValue(10)]
		public int ShipWreckChance = 10;
		[DefaultValue(5)]
		public int OutpostChance = 5;
	}
}
