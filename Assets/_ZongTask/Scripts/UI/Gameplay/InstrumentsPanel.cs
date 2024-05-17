using System.Collections.Generic;
using UnityEngine;

public class InstrumentsPanel : AbstractPanel
{
    [SerializeField] private List<MenuButton> _buttonList;
    [SerializeField] private Inventory _inventory;

    private void Awake()
    {
        Addpanel("InstrumentsPanel", this);

        foreach (var button in _buttonList)
        {
            button.gameObject.SetActive(false);
        }

        HidePanel();
    }

    private void OnEnable()
    {
        foreach (var button in _buttonList)
        {
            button.ButtonSelectItem += SelectItem;

        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttonList)
        {
            button.ButtonSelectItem += SelectItem;
        }
    }

    private void SelectItem(string buttonName)
    {
        foreach(var item in _inventory._characterItems)
        {
            if(item.Key == buttonName)
            {
                item.Value.SetActive(true);
                _inventory._characterItems.Remove(item.Key);
                HideButton(item.Key);
                HidePanel();
                return;
            }
        }

    }

    private void HideButton(string buttonName)
    {
        foreach (var button in _buttonList)
        {
            if(button.tag == buttonName)
            {
                button.gameObject.SetActive(false);
                return;
            }
        }
    }

    private void CheckInventoryItem()
    {
        if (_inventory._characterItems.ContainsKey("StoneLiftCoffin"))
        {
            foreach (var button in _buttonList)
            {
                button.gameObject.SetActive(true);
            }
        }
        else
        {
            return;
        }
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        CheckInventoryItem();
    }

    public override void HidePanel() => base.HidePanel();
}
