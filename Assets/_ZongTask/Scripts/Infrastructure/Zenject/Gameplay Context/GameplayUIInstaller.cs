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
        GameplayPanel gameplayPanel = Container.InstantiatePrefabForComponent<GameplayPanel>(_uiGameObject, _uiGameObject.transform.position, Quaternion.identity, null);

        Container.Bind<GameplayPanel>().
        FromInstance(gameplayPanel).
        AsSingle();
    }
}
