using System.Collections.Generic;
using UnityEngine;

public class GameplayPanelListener : AbstractPanel
{
    [SerializeField] private List<MenuButton> _buttonList;
    private void OnEnable()
    {
        foreach (var button in _buttonList)
        {
            switch (button.tag)
            {
                case "WeaponButton":
                    button.ButtonClick += OpenWeaponPanel;
                    break;
                case "ScoreButton":
                    button.ButtonClick += OpenScorePanel;
                    break;
                case "InstrumentsButton":
                    button.ButtonClick += OpenInstrumentsPanel;
                    break;
            }

        }
    }

    private void OnDestroy()
    {
        foreach (var button in _buttonList)
        {
            switch (button.tag)
            {
                case "WeaponButton":
                    button.ButtonClick -= OpenWeaponPanel;
                    break;
                case "ScoreButton":
                    button.ButtonClick -= OpenScorePanel;
                    break;
                case "InstrumentsButton":
                    button.ButtonClick -= OpenInstrumentsPanel;
                    break;
            }

        }
    }

    private void OpenWeaponPanel()
    {
        foreach (var panel in _menuPanels)
        {

            if (panel.Key.ToString() == "WeaponPanel")
            {
                panel.Value.ShowPanel();
            }
            else
            {
                panel.Value.HidePanel();
            }
        }
    }

    private void OpenScorePanel()
    {
        foreach (var panel in _menuPanels)
        {
            if (panel.Key.ToString() == "ScorePanel")
            {
                panel.Value.ShowPanel();

            }
            else
            {
                panel.Value.HidePanel();
            }
        }
    }

    private void OpenInstrumentsPanel()
    {
        foreach (var panel in _menuPanels)
        {
            if (panel.Key.ToString() == "InstrumentsPanel")
            {
                panel.Value.ShowPanel();
            }
            else
            {
                panel.Value.HidePanel();
            }
        }
    }
}