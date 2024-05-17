using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private XRDeviceSimulator _simulator;
    [SerializeField] private XRRayInteractor _xRRayInteractor;

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
                    GripObject?.Invoke(itemInstance);
                    itemInstance.gameObject.SetActive(false);
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

    private void OpenMenu(InputAction.CallbackContext callbackcontext) => OpenInventoryPanel?.Invoke();
}