using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
    public class GameItems : ScriptableObject
    {
        public ClothItem[] clothItems;
    }
}