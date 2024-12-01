using System;
using DG.Tweening;
using UI.UIPlayingWindow;
using UI.UIService;

namespace Energy
{
    public class EnergyController
    {
        public Action OnAddEnergy;
        public bool IsFull => _isFull;

        private readonly IUIService _uiService;
        private readonly EnergyConfig _energyConfig;

        private UIPlayingWindowView _uiPlayingWindowView;

        private float _maxEnergyCount;
        private float _recoverEnergyCount;
        private float _removerEnergyCount;
        private float _currentEnergyCount;
        private float _delayToAddEnergy;

        private bool _isFull;
        private Tween _addEnergyTween;
        
        public EnergyController(
            IUIService uiService,
            EnergyConfig energyConfig)
        {
            _uiService = uiService;
            _energyConfig = energyConfig;

            _delayToAddEnergy = _energyConfig.DelayToAddEnergy;
            _recoverEnergyCount = _energyConfig.RecoverEnergyCount;
            
            _uiPlayingWindowView = _uiService.Get<UIPlayingWindowView>();
        }

        public void SetAllValues()
        {
            _maxEnergyCount = _energyConfig.MaxEnergyCount;
            _currentEnergyCount = _maxEnergyCount;
            _recoverEnergyCount = _energyConfig.RecoverEnergyCount;
            _removerEnergyCount = _energyConfig.RemoveEnergyCount;

            _isFull = _currentEnergyCount == _maxEnergyCount;
            UpdateText(_currentEnergyCount);
            AddEnergy();
        }

        public void AddEnergy()
        {
            if (_addEnergyTween == null)
            {
                _addEnergyTween = DOVirtual.DelayedCall(_delayToAddEnergy, ()=>
                {
                    _addEnergyTween = null;
                    CheckIsFull();
                    if (!_isFull)
                    {
                        _currentEnergyCount += _recoverEnergyCount;
                        if (_currentEnergyCount > _maxEnergyCount)
                        {
                            _currentEnergyCount = _maxEnergyCount;
                        }
                        
                        UpdateText(_currentEnergyCount);
                        AddEnergy();
                    }
                    else
                    {
                        OnAddEnergy += WaitAddEnergy;
                    }
                });
            }
        }

        public bool CheckRemoveEnergy()
        {
            bool value = _currentEnergyCount > 0;
            return value;
        }

        public void RemoveEnergy()
        {
            _currentEnergyCount -= _removerEnergyCount;
            UpdateText(_currentEnergyCount);
        }

        private void CheckIsFull()
        {
            if (_currentEnergyCount >= _maxEnergyCount)
            {
                _isFull = true;
            }
            else
            {
                _isFull = false;
            }
        }

        private void WaitAddEnergy()
        {
            AddEnergy();
            OnAddEnergy -= WaitAddEnergy;
        }

        private void UpdateText(float value)
        {
            _uiPlayingWindowView.EnergyText.text = "Energy: " + value;
        }
    }
}