using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private XRDeviceSimulator _simulator;
    [SerializeField] private XRRayInteractor _xRRayInteractor;
    [SerializeField] private Transform _backPointTransform;
    [SerializeField] private CharacterController _characterController;

    public event Action<ItemInstance> GripObject;
    public event Action OpenInventoryPanel;

    private void OnEnable()
    {
        _simulator.triggerAction.action.performed += TakeObject;
        _simulator.menuAction.action.performed += OpenMenu;
    }

    private void OnDisable()
    {
        _simulator.gripAction.action.performed -= TakeObject;
        _simulator.menuAction.action.performed -= OpenMenu;
    }

    private void TakeObject(InputAction.CallbackContext callbackcontext)
    {
        if (_simulator.gripAction.action.IsPressed())
        {
            try
            {
                if (_xRRayInteractor.rayEndTransform.gameObject.TryGetComponent(out ItemInstance itemInstance))
                {
                    HideObject(itemInstance);
                    OpenInventoryPanel?.Invoke();
                }
            }
            catch (Exception exeption)
            {
                Debug.LogException(exeption);
            }
        }
        else
        {
            return;
        }
    }

    internal protected void HideObject(ItemInstance itemInstance)
    {
        GripObject?.Invoke(itemInstance);
        itemInstance.transform.SetParent(_xRRayInteractor.gameObject.transform, true);
        itemInstance.gameObject.SetActive(false);
    }

    private void OpenMenu(InputAction.CallbackContext callbackcontext) => OpenInventoryPanel?.Invoke();
    internal protected void Teleport() => _characterController.Move(_backPointTransform.transform.position);
}