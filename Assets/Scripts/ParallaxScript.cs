using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public Transform target;
    public float multiplier;
    public bool lockX, lockY, lockZ;
    
    void Update()
    {
        var newPos = target.position * multiplier;
        if (lockX)
            newPos.x = transform.position.x;
        if (lockY)
            newPos.y = transform.position.y;
        if (lockZ)
            newPos.z = transform.position.z;
        transform.position = newPos;
    }
}
