using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetItem : MonoBehaviour
{
    public Transform from;
    public Camera cam;
    public float? distance;
    public Vector3 dir;

    // Update is called once per frame
    void Update()
    {
        var mp = cam.ScreenToWorldPoint(Input.mousePosition);

        mp.z = 1f;

        dir = from.position - mp;

        if (!distance.HasValue || dir.magnitude < distance.Value)
        {
            this.transform.position = mp;
        }
        else
        {
            var norm = dir.normalized;

            this.transform.position = from.position - (norm * distance.Value);
        }
    }
}
