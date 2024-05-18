using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.TryGetComponent(out ItemInstance itemInstance) && this.gameObject.tag != "BoxC")
        {
            if(itemInstance._itemData._itemName == "StoneLiftCoffin")
            {
                _particleSystem.Play();
            }
        }
    }
}
