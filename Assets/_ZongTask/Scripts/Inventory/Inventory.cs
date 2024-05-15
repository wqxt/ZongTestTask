using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] internal Dictionary<string, GameObject> _items = new();
    public void AddItem(string itemName, GameObject itemToAdd)
    {
        _items.Clear();
        _items.Add(itemName, itemToAdd);
    }
}
