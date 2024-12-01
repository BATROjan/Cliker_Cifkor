using Click;
using Money;

namespace GameController
{
    public class GameController
    {
        private readonly ClickController _clickController;
        private readonly MoneyController _moneyController;

        public GameController(
            ClickController clickController,
            MoneyController moneyController)
        {
            _clickController = clickController;
            _moneyController = moneyController;
        }

        public void StartGame()
        {
           _moneyController.SetAllParamets();
           
           _clickController.SubscribeButton();
           _clickController.ReadyToClick = true;
           _clickController.StartAutoClick();
        }
    }
}