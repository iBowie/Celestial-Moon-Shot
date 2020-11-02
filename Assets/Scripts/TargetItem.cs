using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetItem : MonoBehaviour
{
    public PlayerMovementController pmc;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        var mp = cam.ScreenToWorldPoint(Input.mousePosition);

        mp.z = 1f;

        this.transform.position = mp;
    }
}
