using UnityEngine;
using UnityEngine.EventSystems;

public abstract class AbstractButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public virtual void OnPointerClick(PointerEventData eventData) { }
    public virtual void OnPointerEnter(PointerEventData eventData) { }
    public virtual void OnPointerExit(PointerEventData eventData) { }
}

