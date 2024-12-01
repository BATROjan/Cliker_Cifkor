using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Money
{
    public class MoneyView :MonoBehaviour
    {
        public Text ViewText => _viewText;
        
        [SerializeField] private Text _viewText;
        private void Reinit(Transform transform)
        {
           this.transform.SetParent(transform, false);
           this.transform.localScale = Vector3.one;
        }

        public class Pool : MonoMemoryPool< Transform, MoneyView>
        {
            protected override void Reinitialize( Transform transform, MoneyView view)
            {
                view.Reinit(transform);
            }
        }
    }
}