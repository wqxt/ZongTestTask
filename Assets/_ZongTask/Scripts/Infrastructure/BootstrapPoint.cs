using UnityEngine;
using Zenject;

public class BootstrapPoint : MonoBehaviour
{
    private SceneLoadHandler _sceneLoadHandler;

    [Inject]
    public void Construct(SceneLoadHandler sceneLoadHandler)
    {
        _sceneLoadHandler = sceneLoadHandler;
    }

    private void Awake()
    {
        Cursor.visible = false;
        _sceneLoadHandler.LoadMainMenuScene();
    }
}