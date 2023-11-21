using UnityEngine;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
public class GameItems : ScriptableObject
{
    public Item[] items;
}