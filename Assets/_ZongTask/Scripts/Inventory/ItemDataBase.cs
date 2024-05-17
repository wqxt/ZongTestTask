using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item Data Base")]
public class ItemDataBase : ScriptableObject
{
    public List<Item> _itemDataBase;

    public void BuildItemDataBase()
    {
        _itemDataBase = new List<Item>()
        {
            new Item(0,"StoneLiftCoffin")
        };
    }

    public Item GetItem(string itemName)
    {
        foreach (var item in _itemDataBase)
        {
            if (item._itemName == itemName)
            {
                return item;
            }

        }
        return null;
    }
}
