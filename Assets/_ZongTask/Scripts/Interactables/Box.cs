using System;
using System.Collections;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    public Action<ItemInstance> HideDroppedObject;
    public Action RemoveDroppedObject;
    public Action<string> SetUIText;
    public Action TeleportPlayer;
    public Action ObjectDropped;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ItemInstance itemInstance) && gameObject.tag != "BoxC")
        {
            if (itemInstance._itemData._itemName == "StoneLiftCoffin")
            {
                SetUIText?.Invoke(this.tag);
                ObjectDropped?.Invoke();
                _particleSystem.Play();
            }
        }
        else
        {
            HideDroppedObject?.Invoke(itemInstance);
            TeleportPlayer?.Invoke();
            SetUIText?.Invoke("BoxB");
            ObjectDropped?.Invoke();
            StartCoroutine(ObjectInteraction(itemInstance));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _particleSystem.Stop();
        RemoveDroppedObject?.Invoke();
    }

    private IEnumerator ObjectInteraction(ItemInstance itemInstance)
    {
        yield return new WaitForSeconds(1f);
        RemoveDroppedObject?.Invoke();
    }
}
