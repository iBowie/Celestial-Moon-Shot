﻿using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MeteoriteSpawnerScript : MonoBehaviour
{
    private float lastMeteorite = 0f;
    private float delay = 60f;
    public LootTable table;
    public Transform spawnAt;
    public GameObject meteoritePrefab;
    // Start is called before the first frame update
    void Start()
    {
        lastMeteorite = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 1f), Space.Self);

        if (Time.time - lastMeteorite >= delay)
        {
            delay = Random.Range(30f, 90f);
            lastMeteorite = Time.time;

            var nobj = GameObject.Instantiate(meteoritePrefab);

            nobj.transform.position = spawnAt.position;
            nobj.transform.rotation = spawnAt.rotation;

            nobj.GetComponent<MeteoriteScript>().items = table.Resolve();
        }
    }
}
