using UnityEngine;
using UnityEngine.UI;

namespace UI.UIPlayingWindow
{
    public class UIPlayingWindowView : UIWindow
    {
        public UIButton[] Buttons => buttons;
        
        [SerializeField] private UIButton[] buttons; 
        [SerializeField] private Text rulesText;
        
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