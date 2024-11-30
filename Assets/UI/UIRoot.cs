using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class UIRoot : MonoBehaviour, IUIRoot
    { 
        public ActivateContainer ActivateContainer => activateContainer;
        public Transform DeativateContainer => deactivateContainer;
        public Canvas RootCanvas => canvas;
        
        [SerializeField] private Canvas canvas;
        [SerializeField] private ActivateContainer activateContainer;
        [SerializeField] private Transform deactivateContainer;
    }
}