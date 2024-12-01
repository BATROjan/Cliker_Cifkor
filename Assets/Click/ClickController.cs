using DG.Tweening;
using Energy;
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

        private readonly ClickConfig _clickConfig;
        private readonly IUIService _uiService;
        private readonly MoneyController _moneyController;
        private readonly EnergyController _energyController;

        private float _delayToClick ;
        private bool _readyToClick;
        
        private UIPlayingWindowView _uiPlayingWindow;

        public ClickController(
            ClickConfig clickConfig,
            IUIService uiService,
            MoneyController moneyController,
            EnergyController energyController)
        {
            _clickConfig = clickConfig;
            _uiService = uiService;
            _moneyController = moneyController;
            _energyController = energyController;
            
            _delayToClick = _clickConfig.DelayToAutoClick;
            
            _uiPlayingWindow = _uiService.Get<UIPlayingWindowView>();
        }

        public void SubscribeButton()
        {
            _uiPlayingWindow.Buttons[0].OnClick += ClickLogic;
        }

        public void StartAutoClick()
        {
            DOVirtual.DelayedCall(_delayToClick, ()=>
            {
                if (_readyToClick)
                {
                    ClickLogic();
                    StartAutoClick();
                }
            });
        }

        private void ClickLogic()
        {
            if (_energyController.CheckRemoveEnergy())
            {
                _energyController.RemoveEnergy();
                _energyController.OnAddEnergy?.Invoke();
                
                _moneyController.AddMoney(); 
                _moneyController.UpdateMoneyText();
            }
        }
    }
}