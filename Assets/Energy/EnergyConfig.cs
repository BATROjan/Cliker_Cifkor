using UnityEngine;

namespace Energy
{
    [CreateAssetMenu(fileName = "EnergyConfig", menuName = "Configs/EnergyConfig")]
    
    public class EnergyConfig : ScriptableObject
    {
        public float MaxEnergyCount => maxEnergyCount;
        public float RecoverEnergyCount => recoverEnergyCount;
        public float RemoveEnergyCount => removeEnergyCount;
        public float DelayToAddEnergy => delayToAddEnergy;
        
        [SerializeField] private float maxEnergyCount;
        [SerializeField] private float recoverEnergyCount;
        [SerializeField] private float removeEnergyCount;
        [SerializeField] private float delayToAddEnergy;
    }
}