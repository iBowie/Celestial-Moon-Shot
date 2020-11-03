using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        float spdValue, disValue;
        string spdUnits, disUnits;

        MoonSpeedController.toDisplay(MoonSpeedController.currentSpeed, out spdValue, out spdUnits);
        MoonSpeedController.toDisplay(MoonSpeedController.totalDistance, out disValue, out disUnits);

        scoreText.text = $"Max Reached Speed: {spdValue:0.##} {spdUnits}\nTotal Distance: {disValue:0.##} {disUnits}";
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(1));
    }
}
