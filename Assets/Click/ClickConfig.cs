using UnityEngine;

namespace Click
{
    [CreateAssetMenu(fileName = "ClickConfig", menuName = "Configs/ClickConfig")]
    
    public class ClickConfig: ScriptableObject
    {
        public float DelayToAutoClick => delayToAutoClick;
        [SerializeField] private float delayToAutoClick;
    }
}