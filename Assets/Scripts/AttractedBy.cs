using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AttractedBy : MonoBehaviour
{
    public static readonly List<AttractedBy> attracteds = new List<AttractedBy>();

    [HideInInspector]
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
