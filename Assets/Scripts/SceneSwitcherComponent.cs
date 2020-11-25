using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcherComponent : MonoBehaviour
{
    public void SwitchTo(int index)
    {
        SceneManager.LoadScene(index);
    }
}
