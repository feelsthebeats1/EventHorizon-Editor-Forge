using EditorDatabase.Enums;
using EditorDatabase.Serializable;

namespace EditorDatabase.DataModel
{
	public partial class Component
	{
        partial void OnDataDeserialized(ComponentSerializable serializable, Database database)
        {
            if (!string.IsNullOrEmpty(serializable.CellType))
                CellType = (CellType)serializable.CellType.First();
        }

		partial void OnDataSerialized(ref ComponentSerializable serializable)
        {
            // The generated code writes AmmunitionId twice, and the obsolete value would win.
            // Both references come from the same number, so the one that resolved to a record wins.
            // Skip Ammunition.IsNull here: the saved id must not depend on how the editor names an
            // empty reference.
            serializable.AmmunitionId = Ammunition.Value != 0 ? Ammunition.Value : AmmunitionObsolete.Value;
            serializable.CellType = CellType != CellType.Empty ? ((char)CellType).ToString() : null;
        }

        public CellType CellType;
	}
}
