using System;
using UnityEngine;
using UnityEngine.Events;

public class Harmable : MonoBehaviour
{
    public float health;
    public float maxHealth;

    private void Start()
    {
        if (OnHarm == null)
            OnHarm = new UnityEvent<float>();
        
        if (OnDeath == null)
            OnDeath = new UnityEvent();
    }

    public void Harm(float damage)
    {
        OnHarm.Invoke(damage);

        health -= damage;

        if (health < 0)
        {
            OnDeath.Invoke();

            Destroy(this.gameObject);
        }
    }

    public UnityEvent<float> OnHarm;
    public UnityEvent OnDeath;
}