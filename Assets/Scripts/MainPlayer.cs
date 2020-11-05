using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer mainPlayer { get; private set; }
    
    void Start()
    {
        mainPlayer = this;
    }
}
