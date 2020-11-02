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

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        totalDistance += (currentSpeed / 50f);

        UIText.text = $"Current Moon Speed: {currentSpeed:0.##} m/s\nTotal Distance: {totalDistance:0.##} meters";
    }
}
