using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "SkinsInfo", menuName = "Scriptable Objects/Skin Data")]
    public class SkinsInfo : ScriptableObject
    {
        public SkinData[] skins;
    }
}