using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPanel : MonoBehaviour, IInteractablePanel
{
    [SerializeField] protected static Dictionary<string, IInteractablePanel> _menuPanels = new Dictionary<string, IInteractablePanel>();

    public virtual void Addpanel(string panelName, IInteractablePanel panel) => _menuPanels.Add(panelName, panel);
    public virtual void ShowPanel() => this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    public virtual void HidePanel() => this.gameObject.transform.localScale = new Vector3(0, 0, 0);
}
