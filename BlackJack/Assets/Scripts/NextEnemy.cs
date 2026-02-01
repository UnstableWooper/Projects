using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NextEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    
    public TMPro.TextMeshProUGUI ScoreText{ get ; private set;}

    private GameObject[] _enemyDeck;
    private void Awake()
    {
        GameObject enemyScoreText = GameObject.FindGameObjectWithTag("EnemyScoreText");
        ScoreText = enemyScoreText.GetComponent<TMPro.TextMeshProUGUI>();
    }

    private void Start()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector2(6.5f, 0), Quaternion.identity);
    }
}
