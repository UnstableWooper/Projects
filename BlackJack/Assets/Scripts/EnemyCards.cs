using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableGameObjects;
using Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;


public class EnemyCards : MonoBehaviour
{
    [SerializeField] private EnemyDeck deck;

    [SerializeField] private int maxScoreStop;
    
    private TMPro.TextMeshProUGUI _scoreText;
    private GameObject _gameManager;
    private GameObject _player;
    private NextEnemy _nextEnemy;
    private PickCard _playerPickCard;
    
    private GameObject[] _cards;

    private int _score;
    private bool _stand;

    public void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _nextEnemy = _gameManager.GetComponent<NextEnemy>();
        
        _scoreText = _nextEnemy.ScoreText;
    }
    public void Start()
    {
        _cards = deck.cards;
        _stand = false;
    }

    private void Update()
    {
        if (_player != null)
        {
            _playerPickCard = _player.GetComponent<PickCard>();
        }
        else
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void PlayerStand()
    {
        EnemyHit(); 
        Invoke(nameof(PlayerStand), 0.5f);
    }

    public void EnemyHit()
    {
        Invoke(nameof(Hit), 0.5f);
    }

    private void Hit()
    {
        int i = Random.Range(1, _cards.Length);
        int cv = _cards[i].GetComponent<CardValue>().value; 
        if (!_stand) 
        {
            _score += cv; //cv = Card Value
            _scoreText.text = _score.ToString(); 
            
            if (_score > 21) 
            { 
                _scoreText.color = Color.red; 
                _scoreText.text = _score.ToString(); 
                _stand = true;
            }else 
            if(_score >= maxScoreStop)
            {
                _stand = true;
            }
        }
    }
}