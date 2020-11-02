using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float travelDistance;
    public LayerMask destroyLayerMask;

    private Vector3 lastDistance;

    private void Start()
    {
        lastDistance = this.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var harmable = collision.gameObject.GetComponent<Harmable>();
        if (harmable != null)
        {
            harmable.Harm(damage);
        }

        if ((destroyLayerMask.value & collision.gameObject.layer) != 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;

        var dist = (pos - lastDistance).magnitude;

        travelDistance -= dist;

        if (travelDistance < 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            lastDistance = pos;
        }
    }
}
