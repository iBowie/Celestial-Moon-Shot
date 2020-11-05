using System.Linq;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float travelDistance;
    public LayerMask destroyLayerMask;
    public string[] affectedTags;
    public float knockback;

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
            if (affectedTags != null && affectedTags.Contains(collision.tag))
            {
                Vector2 dir = (harmable.transform.position - transform.position).normalized;

                harmable.Harm(damage, dir * knockback);
            }
        }

        if (destroyLayerMask == (destroyLayerMask | (1 << collision.gameObject.layer)))
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.IsPaused)
            return;

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
