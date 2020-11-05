using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovementAnimator : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    public void SetMove(float value)
    {
        animator.SetFloat("Speed", value);
    }
    public void StartJump()
    {
        animator.SetBool("IsJumping", true);
    }
    public void StopJump()
    {
        animator.SetBool("IsJumping", false);
    }
    public void StartSprint()
    {
        animator.SetBool("IsSprinting", true);
    }
    public void StopSprint()
    {
        animator.SetBool("IsSprinting", false);
    }
}
