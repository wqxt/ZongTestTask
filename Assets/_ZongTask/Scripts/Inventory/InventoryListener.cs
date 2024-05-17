using UnityEngine;
using Zenject;
public class InventoryListener : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private GameplayPanel _gameplayPanel;
    private CharacterController _characterController;

    [Inject]
    public void Construct(CharacterController characterController)
    {
        _characterController = characterController;
    }

    private void Awake()
    {
        _inventory.BuildItemDataBase();
    }

    private void OnEnable()
    {
        _characterController.GripObject += _inventory.AddItem;
        _characterController.OpenInventoryPanel += _gameplayPanel.ShowPanel;
    }

    private void OnDestroy()
    {
        _characterController.GripObject -= _inventory.AddItem;
        _characterController.OpenInventoryPanel -= _gameplayPanel.ShowPanel;
    }
}