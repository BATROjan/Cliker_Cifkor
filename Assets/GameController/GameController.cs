using Click;
using Energy;
using MainCamera;
using Money;
using UI;

namespace GameController
{
    public class GameController
    {
        private readonly AudioController.AudioController _audioController;
        private readonly CameraView _camera;
        private readonly IUIRoot _uiRoot;
        private readonly EnergyController _energyController;
        private readonly ClickController _clickController;
        private readonly MoneyController _moneyController;

        public GameController(
            AudioController.AudioController audioController,
            CameraView camera,
            IUIRoot uiRoot,
            EnergyController energyController,
            ClickController clickController,
            MoneyController moneyController)
        {
            _audioController = audioController;
            _camera = camera;
            _uiRoot = uiRoot;
            _energyController = energyController;
            _clickController = clickController;
            _moneyController = moneyController;
        }

        public void StartGame()
        {
            _energyController.SetAllValues();
           _moneyController.SetAllParamets();
           
           _clickController.SubscribeButton();
           _clickController.ReadyToClick = true;
           _clickController.StartAutoClick();
           
           _audioController.Play(AudioType.Background);
        }
    }
}