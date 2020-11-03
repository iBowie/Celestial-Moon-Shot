using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Harmable : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public float healthPercentage => health / maxHealth;

    public Image healthBarImage;
    public AudioSource audioSource;
    public AudioClip hitSound;

    private float lastHealth, lastMaxHealth;

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

    public void Harm(float damage)
    {
        OnHarm.Invoke(damage);

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