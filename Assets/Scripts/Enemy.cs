using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int scorePerHit = 12; 
    [SerializeField] private GameObject deathFX;

    [SerializeField] private Transform parent;

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
        m_ScoreBoard.ScoreHit(scorePerHit);
        var fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
