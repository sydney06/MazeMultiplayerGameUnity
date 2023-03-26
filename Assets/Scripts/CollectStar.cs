using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectStar : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            collectSound.Play();
            ScoringSystem.score += 1;
            Destroy(gameObject);
        }
    }
}
