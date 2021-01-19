using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int scorePerHit = 12; 
    [SerializeField] private GameObject deathFX;

    [SerializeField] private Transform parent;
    [SerializeField] private int hits = 5;

    private ScoreBoard m_ScoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        AddBoxCollider();
        m_ScoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hits <= 0)
        {
            KillEnemy();
        }
    }

    private void ProcessHit()
    {
        m_ScoreBoard.ScoreHit(scorePerHit);
        hits--;
        // todo consider hit FX
    }

    private void KillEnemy()
    {
        var fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
