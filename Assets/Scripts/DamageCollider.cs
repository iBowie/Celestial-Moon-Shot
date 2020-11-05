using System.Linq;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public float damage;
    public float knockback;
    public string[] affectedTags;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (affectedTags != null && affectedTags.Contains(collision.tag))
        {
            var harmable = collision.gameObject.GetComponent<Harmable>();

            if (harmable != null)
            {
                Vector2 dir = (harmable.transform.position - transform.position + Vector3.up).normalized;

                harmable.Harm(damage, dir * knockback);
            }
        }
    }
}
