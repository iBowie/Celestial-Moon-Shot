using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerMovementController pmc;
    // Start is called before the first frame update
    void Start()
    {
        pmc = GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        bool jump = false;
        bool crouch = false;
        float move = 0f;

        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Jump"))
        {
            jump = true;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move = -1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move = 1f;
        }
        else
        {
            move = Input.GetAxis("Horizontal");
        }

        pmc.Move(move, crouch, jump);
    }
}
