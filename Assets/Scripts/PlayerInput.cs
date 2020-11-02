using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerMovementController pmc;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        pmc = GetComponent<PlayerMovementController>();
        animator = GetComponent<Animator>();
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
            animator.SetBool("IsJumping", true);
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

        animator.SetFloat("Speed", Mathf.Abs(move));

        pmc.Move(move, crouch, jump);
    }

    public void StopJump()
    {
        animator.SetBool("IsJumping", false);
    }
}
