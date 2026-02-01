using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using Random = UnityEngine.Random;

public class PickCard : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText; 
    [SerializeField] private GameObject[] cards;

    private GameObject _enemy;
    private GameObject _gameManager;
    private int _score; 
    private bool _stand;
    
    private void Awake()
    { 
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _score = 0;
        _stand = false;
    }
    
    public void Hit()
    { 
        _enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyCards enemyCards = _enemy.GetComponent<EnemyCards>();
        enemyCards.EnemyHit();
        
        int i = Random.Range(1, cards.Length); 
        int cv = cards[i].GetComponent<CardValue>().value; 
        if (!_stand) 
        {
            _score += cv; //cv = Card Value
            scoreText.text = _score.ToString(); 
            
            if (_score > 21) 
            { 
                scoreText.color = Color.red; 
                scoreText.text = _score.ToString(); 
                _stand = true;
            }
        }
    }
    
    public void Stand()
    { 
        _stand = true; 
    }
}
