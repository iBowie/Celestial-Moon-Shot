using UnityEngine;

[ExecuteInEditMode]
public class LockRotationRelative : MonoBehaviour
{
    public Transform target;
    public bool LockX;
    public bool LockY;
    public bool LockZ;
    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("MainCenter").transform;
        }

        var old = this.transform.rotation;

        this.transform.up = -(target.position - this.transform.position);

        var rot = this.transform.rotation.eulerAngles + Offset;

        this.transform.rotation = Quaternion.Euler(LockX ? old.x : rot.x, LockY ? old.y : rot.y, LockZ ? old.z : rot.z);
    }
}
