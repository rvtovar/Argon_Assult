using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Only Script to load screens 
public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In Seconds")][SerializeField] private float levelLoadDelay = 1f;
   [Tooltip("FX prefab on player")] [SerializeField] private GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke(nameof(ReloadScene), levelLoadDelay);
        
    }
}
