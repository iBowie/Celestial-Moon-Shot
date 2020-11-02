using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonSpeedController : MonoBehaviour
{
    public static MoonSpeedController Instance { get; private set; }

    public float currentSpeed = 0f;
    public float totalDistance = 0f;

    public Text UIText;
    public ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        totalDistance += (currentSpeed / 50f);

        toDisplay(totalDistance, out float disValue, out string disUnits);
        toDisplay(currentSpeed, out float spdValue, out string spdUnits);

        UIText.text = $"Current Moon Speed: {spdValue:0.##} {spdUnits}/s\nTotal Distance: {disValue:0.##} {disUnits}";
    }

    void toDisplay(float value, out float visibleValue, out string units)
    {
        if (value > 1000f)
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
