using System;
using UnityEngine;

public class UseableItemGun : UseableItemBase
{
    private float lastFired;
    private AudioSource audioSource;

    protected event EventHandler OnFired;

    public bool autoAttack;
    public float fireDelay;
    public GameObject bullet;
    public AudioClip fireSound;
    public float bulletVelocity;
    public Transform fireStart;

    protected override void PostAwake()
    {
        lastFired = Time.time;
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnLeftButtonStay()
    {
        if (PauseManager.IsPaused)
            return;

        if (!autoAttack)
            return;

        if (Time.time - lastFired > fireDelay)
        {
            lastFired = Time.time;

            triggerFire();
        }
    }
    public override void OnLeftButtonDown()
    {
        if (PauseManager.IsPaused)
            return;

        if (autoAttack)
            return;

        if (Time.time - lastFired > fireDelay)
        {
            lastFired = Time.time;

            triggerFire();
        }
    }

    void triggerFire()
    {
        var force = -controller.target.dir.normalized * bulletVelocity;

        var nObj = GameObject.Instantiate(bullet);

        if (fireStart == null)
        {
            nObj.transform.position = this.transform.position;
            nObj.transform.rotation = this.transform.rotation;
        }
        else
        {
            nObj.transform.position = fireStart.transform.position;
            nObj.transform.rotation = fireStart.transform.rotation;
        }

        nObj.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);

        audioSource.PlayOneShot(fireSound);

        OnFired?.Invoke(this, new EventArgs());
    }
}
