using UnityEngine;
using UnityEngine.UI;

namespace UI.UIPlayingWindow
{
    public class UIPlayingWindowView : UIWindow
    {
        public UIButton[] Buttons => buttons;
        public Text MoneyText{
            get => moneyText;
            set
            {
               MoneyText = value;
            }
        } 
        public Text EnergyText{
            get => energyText;
            set
            {
                energyText = value;
            }
        }
        [SerializeField] private UIButton[] buttons;
        [SerializeField] private Text moneyText;
        [SerializeField] private Text energyText;
        
        public override void Show()
        {
            ShowAction?.Invoke();
        }

        public override void Hide()
        {
            HideAction?.Invoke();
        }
    }
}