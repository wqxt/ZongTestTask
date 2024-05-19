using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Inventory")]
public class Inventory : ScriptableObject
{
    internal List<ItemInstance> _playerItemList = new();
    public void AddItem(ItemInstance itemInstance)
    {
        _playerItemList.Clear();
        _playerItemList.Add(itemInstance);
    }
}