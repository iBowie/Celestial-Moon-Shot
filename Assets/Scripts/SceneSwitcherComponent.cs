using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherComponent : MonoBehaviour
{
    public void SwitchTo(int index)
    {
        SceneManager.LoadScene(index);
        var scene = SceneManager.GetSceneAt(index);
        SceneManager.SetActiveScene(scene);
    }
}
