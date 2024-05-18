using UnityEngine;
using Zenject;

public class GameplayUIInstaller : MonoInstaller
{
    [SerializeField] private GameObject _uiGameObject;

    public override void InstallBindings()
    {
        UIPrefabInstall();
    }

    private void UIPrefabInstall()
    {
        MainInventoryPanel gameplayPanel = Container.InstantiatePrefabForComponent<MainInventoryPanel>(_uiGameObject, _uiGameObject.transform.position, Quaternion.identity, null);

        Container.Bind<MainInventoryPanel>().
        FromInstance(gameplayPanel).
        AsSingle();
    }
}
