using UnityEngine;

public class LockRotationRelative : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        this.transform.up = -(target.position - this.transform.position);
    }
}
