public class DefaultEnemyAI : EnemyAI
{
    public PlayerMovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<PlayerMovementController>();
    }

    private void FixedUpdate()
    {
        if (movementController.IsFacingRight)
        {
            movementController.Move(1.0f, false, false);
        }
        else
        {
            movementController.Move(-1.0f, false, false);
        }
    }
}