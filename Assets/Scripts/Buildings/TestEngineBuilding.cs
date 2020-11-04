using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEngineBuilding : MonoBehaviour
{
    const float speed = 1f;

    private void OnEnable()
    {
        MoonSpeedController.currentSpeed += speed;
    }

    private void OnDisable()
    {
        MoonSpeedController.currentSpeed -= speed;
    }
}
