﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Harmable : MonoBehaviour, IHasToolTip
{
    public string displayName;
    public float health;
    public float maxHealth;
    public bool knockbackResistant;
    public bool hasInvincibilityTime;
    public bool regenOverTime;

    public float healthPercentage => health / maxHealth;

    public string ToolTip
    {
        get
        {
            if (string.IsNullOrEmpty(displayName))
            {
                return $"{health:N0}/{maxHealth:N0}";
            }
            else
            {
                return $"{displayName}: {health:N0}/{maxHealth:N0}";
            }
        }
    }

    public Image healthBarImage;
    public AudioSource audioSource;
    public AudioClip hitSound;
    public Rigidbody2D rigid;
    public CameraShake cameraShake;

    private float lastHealth, lastMaxHealth;
    private float lastHit, lastRegen;

    private void Start()
    {
        lastHealth = health;
        lastMaxHealth = maxHealth;

        if (OnHarm == null)
            OnHarm = new UnityEvent<float>();

        if (OnDeath == null)
            OnDeath = new UnityEvent();

        UpdateHealthBar();
    }

    public void Harm(float damage, Vector2 force)
    {
        if (hasInvincibilityTime)
        {
            if (Time.time - lastHit <= 0.5f)
            {
                return;
            }
        }

        lastHit = Time.time;

        if (!knockbackResistant)
        {
            rigid.AddForce(force);
        }

        OnHarm.Invoke(damage);

        if (cameraShake != null)
        {
            cameraShake.shakeAmount = Mathf.Clamp01(damage / maxHealth);
            cameraShake.shakeDuration = 0.5f;
        }

        health -= damage;

        if (audioSource != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (health <= 0)
        {
            OnDeath.Invoke();

            Destroy(this.gameObject);
        }
        else
        {
            UpdateHealthBar();
        }
    }

    private void Update()
    {
        if (lastMaxHealth != maxHealth)
        {
            UpdateHealthBar();
        }
        if (lastHealth != health)
        {
            UpdateHealthBar();
        }

        lastMaxHealth = maxHealth;
        lastHealth = health;
    }

    private void FixedUpdate()
    {
        if (regenOverTime)
        {
            if (Time.time - lastHit >= 10f && Time.time - lastRegen >= 3f && health < maxHealth)
            {
                lastRegen = Time.time;

                health = Mathf.Clamp(health + maxHealth * 0.05f, 0f, maxHealth);
            }
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            healthBarImage.fillAmount = healthPercentage;

            float r = 1f - healthPercentage;
            float g = healthPercentage;

            healthBarImage.color = new Color(r, g, 0f);
        }
    }

    public UnityEvent<float> OnHarm;
    public UnityEvent OnDeath;
}