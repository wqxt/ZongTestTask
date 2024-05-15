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

    private void CheckInventoryItem()
    {
        Debug.Log("Check item in tyhe instruments panel");

        if (_inventory._items.ContainsKey("StoneLiftCoffin"))
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
