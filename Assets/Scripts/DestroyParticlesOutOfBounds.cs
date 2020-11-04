using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticlesOutOfBounds : MonoBehaviour
{
    public Bounds bounds;
    private ParticleSystem ps;
    private ParticleSystem.Particle[] particles;
    
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        if (ps == null)
            throw new MissingComponentException("Missing ParticleSystem");
        else
            particles = new ParticleSystem.Particle[ps.main.maxParticles];
    }

    void FixedUpdate()
    {
        var count = ps.GetParticles(particles);
        for (var i = 0; i < count; i++)
        {
            if (!bounds.Contains(particles[i].position))
            {
                particles[i].remainingLifetime = -1.0f;
            }
        }
        ps.SetParticles(particles, count);
    }
}
