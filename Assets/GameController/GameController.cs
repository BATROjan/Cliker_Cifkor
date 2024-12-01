using Click;
using Energy;
using MainCamera;
using Money;
using UI;

namespace GameController
{
    public class GameController
    {
        private readonly CameraView _camera;
        private readonly IUIRoot _uiRoot;
        private readonly EnergyController _energyController;
        private readonly ClickController _clickController;
        private readonly MoneyController _moneyController;

        public GameController(
            CameraView camera,
            IUIRoot uiRoot,
            EnergyController energyController,
            ClickController clickController,
            MoneyController moneyController)
        {
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
        }
    }
}