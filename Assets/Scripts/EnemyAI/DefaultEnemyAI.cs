public class DefaultEnemyAI : EnemyAI
{
    public PlayerMovementController movementController;
    public Harmable harmable;

    private void Start()
    {
        movementController = GetComponent<PlayerMovementController>();
        movementController.SetTarget(MainPlayer.mainPlayer.transform);
        movementController.HandRotation.target = MainPlayer.mainPlayer.transform;

        harmable = GetComponent<Harmable>();
    }

    private void FixedUpdate()
    {
        if (PauseManager.IsPaused)
            return;

        // bool doJump = movementController.HandRotation.transform.rotation.eulerAngles.z >= 45f;
        bool doJump = false;

        if (movementController.IsFacingRight)
        {
            movementController.Move(1.0f, jump: doJump, sprint: harmable.healthPercentage <= 0.5f);
        }
        else
        {
            movementController.Move(-1.0f, jump: doJump, sprint: harmable.healthPercentage <= 0.5f);
        }
    }
}