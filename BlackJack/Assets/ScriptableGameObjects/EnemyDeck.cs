using UnityEngine;

namespace ScriptableGameObjects
{
    [CreateAssetMenu(fileName = "Hand", menuName = "ScriptableObjects/Hand", order = 1)]
    public class EnemyDeck : ScriptableObject
    {
        public GameObject[] cards; 
    }
}
