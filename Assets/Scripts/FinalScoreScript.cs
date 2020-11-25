using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScoreScript : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        float disValue;
        string disUnits;

        MoonSpeedController.toDisplay(MoonSpeedController.totalDistance, out disValue, out disUnits);

        scoreText.text = $"Total Distance: {disValue:0.##} {disUnits}";
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
