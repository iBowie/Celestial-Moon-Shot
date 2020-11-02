using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractedBy : MonoBehaviour
{
    public static readonly List<AttractedBy> attracteds = new List<AttractedBy>();

    public Rigidbody2D rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        attracteds.Add(this);
    }
    private void OnDisable()
    {
        attracteds.Remove(this);
    }
}
