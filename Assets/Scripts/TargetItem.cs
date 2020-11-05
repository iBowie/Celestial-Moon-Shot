using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetItem : MonoBehaviour
{
    public Transform from;
    public Camera cam;
    public float? distance;
    public Vector3 dir;
    public Text tooltipText;
    public Collider2D tooltipCollider;

    // Update is called once per frame
    void Update()
    {
        var mp = cam.ScreenToWorldPoint(Input.mousePosition);

        mp.z = 1f;

        dir = from.position - mp;

        if (!distance.HasValue || dir.magnitude < distance.Value)
        {
            this.transform.position = mp;
        }
        else
        {
            var norm = dir.normalized;

            this.transform.position = from.position - (norm * distance.Value);
        }
    }
    private void LateUpdate()
    {
        List<Collider2D> results = new List<Collider2D>();
        Physics2D.OverlapCollider(tooltipCollider, new ContactFilter2D(), results);

        string newTooltip = string.Empty;

        if (results.Count > 0)
        {
            foreach (var res in results)
            {
                IHasToolTip has = (IHasToolTip)res.gameObject.GetComponent(typeof(IHasToolTip));
                if (has != null)
                {
                    newTooltip = has.ToolTip;
                    break;
                }
            }
        }

        tooltipText.text = newTooltip ?? string.Empty;
    }
}
