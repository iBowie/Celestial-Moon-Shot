using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerScript : MonoBehaviour
{
    public Transform left, right;
    public Image leftWarning, rightWarning;
    public Animator leftWarningAnimation, rightWarningAnimation;
    public float spawnDelay = 10f;

    public EnemyTable table;

    [SerializeField]
#if Editor
    [ReadOnly]
#endif
    private float spawnTime;

    private Animator warnAnimator;

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
            Image warnSide;

            if (Random.value >= 0.5f)
            {
                side = left;
                warnSide = leftWarning;
                warnAnimator = leftWarningAnimation;
            }
            else
            {
                side = right;
                warnSide = rightWarning;
                warnAnimator = rightWarningAnimation;
            }

            if (table == null)
                return;

            var pr = table.Resolve();
            if (pr == null)
                return;

            var obj = GameObject.Instantiate(pr);

            obj.transform.position = side.transform.position;

            warnAnimator.SetBool("Flash", true);
        }
        else
        {
            warnAnimator?.SetBool("Flash", false);
        }
    }
}
