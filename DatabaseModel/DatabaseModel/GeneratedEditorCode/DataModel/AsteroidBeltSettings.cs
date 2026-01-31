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
	public partial class AsteroidBeltSettings
	{
		partial void OnDataDeserialized(AsteroidBeltSettingsSerializable serializable, Database database);
		partial void OnDataSerialized(ref AsteroidBeltSettingsSerializable serializable);

		public static AsteroidBeltSettings Create(AsteroidBeltSettingsSerializable serializable, Database database)
		{
			if (serializable == null) return DefaultValue;
			return new AsteroidBeltSettings(serializable, database);
		}

		public AsteroidBeltSettings() {}

		private AsteroidBeltSettings(AsteroidBeltSettingsSerializable serializable, Database database)
		{
			MeteoriteChance = new NumericValue<int>(serializable.MeteoriteChance, -2147483648, 2147483647);
			ContainerChance = new NumericValue<int>(serializable.ContainerChance, -2147483648, 2147483647);
			ShipWreckChance = new NumericValue<int>(serializable.ShipWreckChance, -2147483648, 2147483647);
			OutpostChance = new NumericValue<int>(serializable.OutpostChance, -2147483648, 2147483647);
			OnDataDeserialized(serializable, database);
		}

		public AsteroidBeltSettingsSerializable Serialize()
		{
			var serializable = new AsteroidBeltSettingsSerializable();
			serializable.MeteoriteChance = MeteoriteChance.Value;
			serializable.ContainerChance = ContainerChance.Value;
			serializable.ShipWreckChance = ShipWreckChance.Value;
			serializable.OutpostChance = OutpostChance.Value;
			OnDataSerialized(ref serializable);
			return serializable;
		}

		public NumericValue<int> MeteoriteChance = new NumericValue<int>(0, -2147483648, 2147483647);
		public NumericValue<int> ContainerChance = new NumericValue<int>(0, -2147483648, 2147483647);
		public NumericValue<int> ShipWreckChance = new NumericValue<int>(0, -2147483648, 2147483647);
		public NumericValue<int> OutpostChance = new NumericValue<int>(0, -2147483648, 2147483647);

		public static AsteroidBeltSettings DefaultValue { get; private set; }
	}
}
