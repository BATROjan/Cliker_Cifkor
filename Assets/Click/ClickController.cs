using DG.Tweening;
using Money;
using UI.UIPlayingWindow;
using UI.UIService;
using Zenject;

namespace Click
{
    public class ClickController 
    {
        public bool ReadyToClick{
            get => _readyToClick;
            set
            {
                _readyToClick = value;
            }
        }
        
        private readonly IUIService _uiService;
        private readonly MoneyController _moneyController;
        
        private float _delayToClick = 3f;
        private bool _readyToClick;
        
        private UIPlayingWindowView _uiPlayingWindow;

        public ClickController(
            IUIService uiService,
            MoneyController moneyController)
        {
            _uiService = uiService;
            _moneyController = moneyController;
            
            _uiPlayingWindow = _uiService.Get<UIPlayingWindowView>();
        }

        public void SubscribeButton()
        {
            _uiPlayingWindow.Buttons[0].OnClick += _moneyController.AddMoney;
            _uiPlayingWindow.Buttons[0].OnClick += _moneyController.UpdateMoneyText;
        }

        public void StartAutoClick()
        {
            DOVirtual.DelayedCall(_delayToClick, ()=>
            {
                if (_readyToClick)
                {
                    AutoClickLogic();
                    StartAutoClick();
                }
            });
        }

        private void AutoClickLogic()
        {
            _moneyController.AddMoney(); 
            _moneyController.UpdateMoneyText();
        }
    }
}