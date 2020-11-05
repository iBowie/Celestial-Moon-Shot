public class DefaultEnemyAI : EnemyAI
{
    public PlayerMovementController movementController;

    private void Start()
    {
        movementController = GetComponent<PlayerMovementController>();
        movementController.SetTarget(MainPlayer.mainPlayer.transform);
        movementController.HandRotation.target = MainPlayer.mainPlayer.transform;
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