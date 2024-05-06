using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Scriptable Object/Scene Load Handler")]
public class SceneLoadHandler : ScriptableObject
{
    public void Initialization() => LoadMainMenuScene();

    public void LoadMainMenuScene() => SceneManager.LoadScene(1);

    public void LoadGamePlayScene() => SceneManager.LoadScene(2);
}
