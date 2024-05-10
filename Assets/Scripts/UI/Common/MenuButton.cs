using System;
using UnityEngine.EventSystems;

public class MenuButton : AbstractButton
{
    public Action ButtonClick;
    public override void OnPointerClick(PointerEventData eventData) => ButtonClick?.Invoke();
}