using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartButtonScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        var scene = SceneManager.GetSceneAt(1);
        SceneManager.SetActiveScene(scene);
    }
}
