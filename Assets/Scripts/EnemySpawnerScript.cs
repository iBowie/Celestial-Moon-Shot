using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public Transform left, right;
    public float spawnDelay = 10f;

    public EnemyTable table;

    [SerializeField]
    [ReadOnly]
    private float spawnTime;

    private void Start()
    {
        spawnTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (PauseManager.IsPaused)
            return;

        if (Time.time - spawnTime >= spawnDelay)
        {
            spawnTime = Time.time;

            Transform side;

            if (Random.value >= 0.5f)
            {
                side = left;
            }
            else
            {
                side = right;
            }

            if (table == null)
                return;

            var pr = table.Resolve();
            if (pr == null)
                return;

            var obj = GameObject.Instantiate(pr);

            obj.transform.position = side.transform.position;
        }
    }
}
