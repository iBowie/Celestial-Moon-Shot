﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoonSpeedController : MonoBehaviour
{
    public static MoonSpeedController Instance { get; private set; }

    private static float oldCurrentSpeed = 0f;
    public static float currentSpeed = 0f;
    public static float totalDistance = 0f;

    public float parallax;
    public Text UIText;
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        currentSpeed = 0f;
        totalDistance = 0f;
    }

    void FixedUpdate()
    {
        if (PauseManager.IsPaused)
            return;

        totalDistance += (currentSpeed / 50f);

        toDisplay(totalDistance, out float disValue, out string disUnits);
        toDisplay(currentSpeed, out float spdValue, out string spdUnits);

        UIText.text = $"Current Moon Speed: {spdValue:0.##} {spdUnits}/s\nTotal Distance: {disValue:0.##} {disUnits}";

        if (oldCurrentSpeed != currentSpeed)
        {
            var ps = particles;
            var v = ps.velocityOverLifetime;
            v.speedModifierMultiplier = currentSpeed * parallax;
        }
        oldCurrentSpeed = currentSpeed;
    }

    public void GoToFinalScore()
    {
        SceneManager.LoadScene(2);
    }

    public static void toDisplay(float value, out float visibleValue, out string units)
    {
        if (value > 149600000f)
        {
            visibleValue = value / 149600000f;
            units = "au";
        }
        else if (value > 1000f)
        {
            visibleValue = value / 1000f;
            units = "km";
        }
        else
        {
            visibleValue = value;
            units = "m";
        }
    }
}
