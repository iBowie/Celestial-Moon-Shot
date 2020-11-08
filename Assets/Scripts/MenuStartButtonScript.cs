using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartButtonScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
        var scene = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(scene);
    }
}
