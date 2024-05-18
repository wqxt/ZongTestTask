using System.Collections.Generic;
using UnityEngine;

public class MainInventoryPanel : AbstractPanel
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
                case "ClosePanelButton":
                    button.ButtonClick += HidePanel;
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
                case "ClosePanelButton":
                    button.ButtonClick -= HidePanel;
                    break;
            }

        }
    }
    private void Awake()
    {
        HidePanel();
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

    public override void HidePanel() => gameObject.SetActive(false);

    public override void ShowPanel()
    {
        gameObject.SetActive(true);
        transform.position = Camera.main.transform.TransformPoint(Vector3.forward * 2);
        transform.rotation = Camera.main.transform.rotation;
    }
}