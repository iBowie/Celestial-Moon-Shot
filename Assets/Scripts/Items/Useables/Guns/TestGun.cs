using UnityEngine;

public class TestGun : UseableItemGun
{
    public TestGun()
    {
        reachDistance = null;
        
        bulletVelocity = 100f;
        autoAttack = false;
        fireDelay = 1f;
    }
}
