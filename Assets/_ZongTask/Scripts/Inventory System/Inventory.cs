using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Inventory")]
public class Inventory : ScriptableObject
{
    internal List<ItemInstance> _playerItemList = new();

    public event Action ItemAdded;
    public void AddItem(ItemInstance itemInstance)
    {
        _playerItemList.Add(itemInstance);
        ItemAdded?.Invoke();
    }
}