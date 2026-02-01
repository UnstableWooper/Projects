using System;
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
    private NextEnemy _nextEnemy;
    
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

    public void EnemyHit()
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