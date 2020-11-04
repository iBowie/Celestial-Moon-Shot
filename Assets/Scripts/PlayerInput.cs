using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInventory))]
public class PlayerInput : MonoBehaviour
{
    PlayerMovementController pmc;
    Animator animator;
    PlayerInventory inv;
    // Start is called before the first frame update
    void Start()
    {
        pmc = GetComponent<PlayerMovementController>();
        animator = GetComponent<Animator>();
        inv = GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        bool jump = false;
        bool sprint = false;
        float move = 0f;

        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = true;
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
        animator.SetBool("IsSprinting", sprint);

        var scr = Input.GetAxis("Mouse ScrollWheel");

        if (scr > 0)
        {
            if (inv.UniqueItems > 0)
            {
                if (inv.selectedItem > 0)
                {
                    inv.selectedItem--;
                }
                else
                {
                    inv.selectedItem = inv.UniqueItems - 1;
                }
            }
        }
        else if (scr < 0)
        {
            if (inv.UniqueItems > 0)
            {
                if (inv.selectedItem < inv.UniqueItems - 1)
                {
                    inv.selectedItem++;
                }
                else
                {
                    inv.selectedItem = 0;
                }
            }
        }

        pmc.Move(move, sprint, jump);
    }

    public void StopJump()
    {
        animator.SetBool("IsJumping", false);
    }
}
