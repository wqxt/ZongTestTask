using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Inventory")]
public class Inventory : ScriptableObject
{
    internal List<ItemInstance> _characterItems = new();
    public void AddItem(ItemInstance itemInstance)
    {
        _characterItems.Clear();
        _characterItems.Add(itemInstance);
    }
}