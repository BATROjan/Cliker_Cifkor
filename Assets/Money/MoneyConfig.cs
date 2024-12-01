using UnityEngine;

namespace Money
{
    [CreateAssetMenu(fileName = "MoneyConfig", menuName = "Configs/MoneyConfig")]
    
    public class MoneyConfig : ScriptableObject
    {
        public int MoneyAddCount => moneyAddCount;
        
        [SerializeField] private int moneyAddCount;
    }
}