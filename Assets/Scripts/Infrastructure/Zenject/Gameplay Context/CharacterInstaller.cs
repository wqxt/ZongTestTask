using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private GameObject _characterController;
    [SerializeField] private Transform _characterTransform;
    public override void InstallBindings()
    {
        CharacterPrefabInstall();

    }

    private void CharacterPrefabInstall()
    {
        CharacterController characterController = Container.InstantiatePrefabForComponent<CharacterController>(_characterController, _characterTransform.position, Quaternion.Euler(0, 90, 0), null);

        Container.Bind<CharacterController>().
        FromInstance(characterController).
        AsSingle();
    }
}
