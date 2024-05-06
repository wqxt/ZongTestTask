using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterInstaller : MonoInstaller
{
    [SerializeField] private GameObject _character;
    [SerializeField] private Transform _characterTransform;
    public override void InstallBindings()
    {
        CharacterPrefabInstall();

    }

    private void CharacterPrefabInstall()
    {
        Character character = Container.InstantiatePrefabForComponent<Character>(_character, _characterTransform.position, Quaternion.Euler(0, 90, 0), null);

        Container.Bind<Character>().
        FromInstance(character).
        AsSingle();
    }
}
