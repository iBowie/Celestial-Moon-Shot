﻿using System.Collections.Generic;
using UnityEngine;

public class MeteoriteScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Collider2D explodeCollider;
    public GameObject dropPrefab;
    public byte[] items;

    void Start()
    {
        if (items == null)
            items = new byte[0];

        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(Vector2.down * 10f, ForceMode2D.Impulse);
        rb.angularVelocity = 360f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        List<Collider2D> results = new List<Collider2D>();
        Physics2D.OverlapCollider(explodeCollider, new ContactFilter2D(), results);
        foreach (var r in results)
        {
            Harmable harmable = r.gameObject.GetComponent<Harmable>();
            if (harmable != null)
            {
                float distance = (harmable.transform.position - transform.position).magnitude;
                harmable.Harm(distance / 5f * 100f, Vector2.zero);
            }
        }

        foreach (var i in items)
        {
            if (ItemResolver.Instance.TryGetItem(i, out _))
            {
                var dp = GameObject.Instantiate(dropPrefab);
                var dropScript = dp.GetComponent<ItemDropScript>();

                var dpPos = transform.position;
                dp.transform.position = dpPos;

                dropScript.itemId = i;
                dropScript.itemCount = 1;
            }
        }

        Destroy(this.gameObject);
    }
}
