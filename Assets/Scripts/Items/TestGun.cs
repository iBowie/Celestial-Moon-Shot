using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun : ItemBase
{
    public GameObject bullet;

    public TestGun()
    {
        reachDistance = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var force = target.dir * -10f;

            var nObj = GameObject.Instantiate(bullet);

            nObj.transform.position = target.transform.position;
            nObj.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }
    }
}
