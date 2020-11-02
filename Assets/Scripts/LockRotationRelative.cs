using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotationRelative : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.up = -(target.position - this.transform.position);
    }
}
