using UnityEngine;

public class Attractor : MonoBehaviour
{
    const float G = 667.4f;
    public float mass;

    private void FixedUpdate()
    {
        foreach (var a in AttractedBy.attracteds)
        {
            Vector2 direction = this.transform.position - a.transform.position;

            // float distance = direction.sqrMagnitude;

            // if (distance == 0)
            //    return;

            // float forceMagnitude = G * (mass * a.rigid.mass) / distance;
            float forceMagnitude = 9.807f;
            Vector2 force = direction.normalized * forceMagnitude * a.rigid.gravityScale;

            a.rigid.AddForce(force);
        }
    }
}
