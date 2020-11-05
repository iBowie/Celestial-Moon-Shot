using UnityEngine;

[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInventory))]
public class PlayerInput : MonoBehaviour
{
    PlayerMovementController pmc;
    Animator animator;
    PlayerInventory inv;
    PlayerUI ui;

    private bool jump, sprint;
    private float move;
    // Start is called before the first frame update
    void Start()
    {
        pmc = GetComponent<PlayerMovementController>();
        animator = GetComponent<Animator>();
        inv = GetComponent<PlayerInventory>();
        ui = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        jump = false;
        sprint = false;
        move = 0f;

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

        if (!PauseManager.IsPaused)
        {
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
        }

        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
        {
            ui.ToggleInventory();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ui.ToggleCrafting();
        }
    }
    private void FixedUpdate()
    {
        if (PauseManager.IsPaused)
            return;

        pmc.Move(move, sprint, jump);
    }

    public void StopJump()
    {
        animator.SetBool("IsJumping", false);
    }
}
