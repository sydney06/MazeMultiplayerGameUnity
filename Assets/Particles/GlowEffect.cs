using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    // top transform of the ParticleSystems
    [SerializeField] private Transform particleEffectXform;

    // delay before particles trigger
    [SerializeField] private float delay = 1f;

    [SerializeField] private AudioSource effectAudio;

    public void PlayEffect()
    {
        StartCoroutine(PlayEffectRoutine());
    }

    // find all of the ParticleSystem components and play
    IEnumerator PlayEffectRoutine()
    {
        // wait for a delay
        yield return new WaitForSeconds(delay);

        // find ParticleSystems under the top transform
        if (particleEffectXform != null)
        {
            ParticleSystem[] particleSystems = particleEffectXform.GetComponentsInChildren<ParticleSystem>();

            // stop and play each ParticleSystem
            foreach (ParticleSystem ps in particleSystems)
            {
                if (ps != null)
                {
                    effectAudio.Play();
                    ps.Stop();
                    ps.Play();
                }
            }
        }
    }

    public void StopEffect()
    {
        if (particleEffectXform != null)
        {
            ParticleSystem[] particleSystems = particleEffectXform.GetComponentsInChildren<ParticleSystem>();

            foreach (ParticleSystem ps in particleSystems)
            {
                if (ps != null)
                {
                    effectAudio.Stop();
                    ps.Stop();
                }
            } 
        }
    }
}
