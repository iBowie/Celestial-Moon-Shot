using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun : ItemBase
{
    public GameObject bullet;

    public TestGun()
    {
        reachDistance = null;
        displayName = "Test Gun";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var force = target.dir.normalized * -100f;

            var nObj = GameObject.Instantiate(bullet);

            nObj.transform.position = target.from.position;
            nObj.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }
    }
}
