using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private Transform _characterTransform;
    public override void InstallBindings()
    {
        CharacterPrefabInstall();
    }

    private void CharacterPrefabInstall()
    {
        CharacterController characterPrefab = Container.InstantiatePrefabForComponent<CharacterController>(_characterPrefab, _characterTransform.position, Quaternion.Euler(0, 90, 0), null);

        Container.Bind<CharacterController>().
        FromInstance(characterPrefab).
        AsSingle();
    }
}