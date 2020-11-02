using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class GunBase : ItemBase
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        lastFired = Time.time;
    }

    public bool autoAttack;
    public float fireDelay;
    public GameObject bullet;
    public AudioClip fireSound;
    public float bulletVelocity;
    public Transform fireStart;

    float lastFired = 0f;
    private void Update()
    {
        if ((autoAttack && Input.GetMouseButton(0)) || (Input.GetMouseButtonDown(0)))
        {
            if (Time.time - lastFired > fireDelay)
            {
                lastFired = Time.time;

                triggerFire();
            }
        }
    }

    void triggerFire()
    {
        var force = -target.dir.normalized * bulletVelocity;

        var nObj = GameObject.Instantiate(bullet);

        nObj.transform.position = fireStart.transform.position;
        nObj.transform.rotation = fireStart.transform.rotation;

        nObj.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);

        audioSource.PlayOneShot(fireSound);
    }
}
public class TestGun : ItemBase
{
    public GameObject bullet;

    public TestGun()
    {
        reachDistance = null;
        displayName = "Test Gun";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var force = target.dir.normalized * -100f;

            var nObj = GameObject.Instantiate(bullet);

            nObj.transform.position = target.from.position + target.dir.normalized * -1f;
            nObj.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }
    }
}
