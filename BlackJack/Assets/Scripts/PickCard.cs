using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class PickCard : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText; 
    [SerializeField] private GameObject[] cards;

    private EnemyCards _enemyCards;
    private GameObject _enemy;
    private GameObject _gameManager;
    private int _score; 
    public bool IsStanding {get;set;}
    
    private void Awake()
    { 
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _score = 0;
        IsStanding = false;
    }

    private void Update()
    {
        _enemy = GameObject.FindGameObjectWithTag("Enemy");
        _enemyCards = _enemy.GetComponent<EnemyCards>();
    }
    
    public void Hit()
    {
        _enemyCards.EnemyHit();
        
        int i = Random.Range(1, cards.Length); 
        int cv = cards[i].GetComponent<CardValue>().value; 
        if (!IsStanding) 
        {
            _score += cv; //cv = Card Value
            scoreText.text = _score.ToString(); 
            
            if (_score > 21) 
            { 
                scoreText.color = Color.red; 
                scoreText.text = _score.ToString(); 
                IsStanding = true;
            }
        }
    }
    
    public void Stand()
    { 
        IsStanding = true;
        _enemyCards.PlayerStand();
    }
}
