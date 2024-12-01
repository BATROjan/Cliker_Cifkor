using Click;
using Energy;
using Money;

namespace GameController
{
    public class GameController
    {
        private readonly EnergyController _energyController;
        private readonly ClickController _clickController;
        private readonly MoneyController _moneyController;

        public GameController(
            EnergyController energyController,
            ClickController clickController,
            MoneyController moneyController)
        {
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