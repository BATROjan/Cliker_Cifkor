using UI.UIPlayingWindow;
using UI.UIService;
using UnityEngine;
using UnityEngine.UI;

namespace Money
{
    public class MoneyController
    {
        public int CurrentMoneyCount => _currentMoneyCount;

        private readonly IUIService _uiService;
        private readonly MoneyConfig _moneyConfig;
        
        private int _addMoneyCount;
        private int _currentMoneyCount;
        
        private UIPlayingWindowView _uiPlayingWindow;
        
        public MoneyController(
            IUIService uiService,
            MoneyConfig moneyConfig)
        {
            _uiService = uiService;
            _moneyConfig = moneyConfig;
            
            _uiPlayingWindow = _uiService.Get<UIPlayingWindowView>();
        }

        public void SetAllParamets()
        {
            _addMoneyCount = _moneyConfig.MoneyAddCount;
        }
        public void AddMoney()
        {
            _currentMoneyCount += _addMoneyCount;
        }
        
        public void UpdateMoneyText()
        {
            _uiPlayingWindow.MoneyText.text = _currentMoneyCount.ToString();
        }
    }
}