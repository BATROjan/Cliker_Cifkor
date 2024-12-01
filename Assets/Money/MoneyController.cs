using System.Collections.Generic;
using Constantces;
using DG.Tweening;
using UI;
using UI.UIPlayingWindow;
using UI.UIService;
using UnityEngine;
using UnityEngine.UI;

namespace Money
{
    public class MoneyController
    {
        public int CurrentMoneyCount => _currentMoneyCount;

        private readonly IUIRoot _uiRoot;
        private readonly MoneyView.Pool _moneyPool;
        private readonly IUIService _uiService;
        private readonly MoneyConfig _moneyConfig;
        
        private int _addMoneyCount;
        private int _currentMoneyCount;
        private float _endYValue = 10;
        private float _rangeXValue = 3f;
        private float _moveAnimationDuration = 0.3f;

        private List<MoneyView> _moneyViewsList = new List<MoneyView>();
        private UIPlayingWindowView _uiPlayingWindow;
        private Transform _transformForMoeyView;
        public MoneyController(
            IUIRoot uiRoot,
            MoneyView.Pool moneyPool,
            IUIService uiService,
            MoneyConfig moneyConfig)
        {
            _uiRoot = uiRoot;
            _moneyPool = moneyPool;
            _uiService = uiService;
            _moneyConfig = moneyConfig;
            
            _uiPlayingWindow = _uiService.Get<UIPlayingWindowView>();
            _transformForMoeyView = uiRoot.ActivateContainer.Layers[ResourcesConst.ObjectLayer];
        }

        public void SetAllParamets()
        {
            _addMoneyCount = _moneyConfig.MoneyAddCount;
        }
        public void AddMoney()
        {
            _currentMoneyCount += _addMoneyCount;
           var money = _moneyPool.Spawn(_transformForMoeyView);
           _moneyViewsList.Add(money);
           
           var vector3 = money.ViewText.transform.position;
           vector3 = new Vector3(Random.Range(-_rangeXValue, _rangeXValue),1,90);
           money.ViewText.transform.position = vector3;
           
           money.ViewText.transform.DOMoveY(_endYValue, _moveAnimationDuration).SetEase(Ease.Linear).OnComplete(() =>
           {
               _moneyPool.Despawn(money);
               _moneyViewsList.Remove(money);
           });
        }
        
        public void UpdateMoneyText()
        {
            _uiPlayingWindow.MoneyText.text = _currentMoneyCount.ToString();
        }
    }
}