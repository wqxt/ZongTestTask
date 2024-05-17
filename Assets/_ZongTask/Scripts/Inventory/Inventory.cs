using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Inventory")]
public class Inventory : ItemDataBase
{
    [SerializeField] internal Dictionary<string, GameObject> _characterItems = new();

    public void AddItem(string itemName, GameObject itemObject)
    {
        Item itemToAdd = GetItem(itemName);
        
        if(itemToAdd != null)
        {
            _characterItems.Add(itemToAdd._itemName, itemObject);
        }
    }
}