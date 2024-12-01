using Constantces;
using Money;
using UI.UIService;

namespace UI.UIPlayingWindow
{
    public class UIPlayingWindowController
    {
        private readonly GameController.GameController _gameController;
        private readonly MoneyController _moneyController;
        private readonly IUIService _uiService;
        private UIPlayingWindowView _uiPlayingWindow;

        public UIPlayingWindowController(
            GameController.GameController gameController,
            MoneyController moneyController,
            IUIService uiService)
        {
            _gameController = gameController;
            _moneyController = moneyController;
            _uiService = uiService;
            _uiPlayingWindow = _uiService.Get<UIPlayingWindowView>();
            
            _uiPlayingWindow.ShowAction += Show;
            _uiPlayingWindow.HideAction += Hide;

            _uiService.Show<UIPlayingWindowView>(ResourcesConst.UILayer);
        }

        private void Hide()
        {
            UnSubscribeButtons();
        }

        private void Show()
        {
            _gameController.StartGame();
            InitButtons();
        }

        private void UnSubscribeButtons()
        {
        }

        private void InitButtons()
        {
        }
    }
}