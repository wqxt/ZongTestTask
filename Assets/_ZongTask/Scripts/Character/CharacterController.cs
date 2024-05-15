using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private XRDeviceSimulator _simulator;
    [SerializeField] private XRRayInteractor _xRRayInteractorLeft;
    [SerializeField] private XRRayInteractor _xRRayInteractorRight;

    public event Action<string, GameObject> GripObject;
    public event Action OpenInventoryPanel;


    private void Awake()
    {
        Debug.Log($"{this} is installed");
    }
    private void OnEnable()
    {
        _simulator.gripAction.action.performed += Grip;
        _simulator.menuAction.action.performed += OpenMenu;
    }

    private void OnDisable()
    {
        _simulator.gripAction.action.performed -= Grip;
        _simulator.menuAction.action.performed -= OpenMenu;
    }

    private void Grip(InputAction.CallbackContext callbackcontext)
    {
        try
        {
            if (_xRRayInteractorLeft.rayEndTransform.tag == "StoneLiftCoffin" || _xRRayInteractorRight.rayEndTransform.tag == "StoneLiftCoffin")
            {
                GameObject gripObject = _xRRayInteractorLeft.rayEndTransform.gameObject;
                gripObject.gameObject.SetActive(false);
                gripObject.transform.SetParent(_xRRayInteractorLeft.rayEndTransform, true);
                GripObject?.Invoke("StoneLiftCoffin", gripObject);
                OpenInventoryPanel?.Invoke();
            }
        }
        catch (Exception)
        {
            return;
        }
    }

    private void OpenMenu(InputAction.CallbackContext callbackcontext) => OpenInventoryPanel?.Invoke();
}