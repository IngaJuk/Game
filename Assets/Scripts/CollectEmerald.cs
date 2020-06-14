﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEmerald : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        ScoringSystem.theScore += 1;        
        Destroy(gameObject);
    }
}
