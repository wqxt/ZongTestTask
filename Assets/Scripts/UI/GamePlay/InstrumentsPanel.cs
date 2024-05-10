using System.Collections.Generic;
using UnityEngine;

public class InstrumentsPanel : AbstractPanel
{
    [SerializeField] private List<MenuButton> _buttonList;

    private void Awake()
    {
        Addpanel("InstrumentsPanel", this);
        HidePanel();
    }

    public override void ShowPanel() => base.ShowPanel();
    public override void HidePanel() => base.HidePanel();
}
