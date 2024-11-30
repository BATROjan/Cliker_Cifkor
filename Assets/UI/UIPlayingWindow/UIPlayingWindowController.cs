using UI.UIService;

namespace UI.UIPlayingWindow
{
    public class UIPlayingWindowController
    {
        private readonly IUIService _uiService;
        private UIPlayingWindowView _uiPlayingWindow;

        public UIPlayingWindowController(
            IUIService uiService)
        {
            _uiService = uiService;
            _uiPlayingWindow = _uiService.Get<UIPlayingWindowView>();
            
            _uiPlayingWindow.ShowAction += Show;
            _uiPlayingWindow.HideAction += Hide;
        }

        private void Hide()
        {
            UnSubscribeButtons();
        }

        private void Show()
        {
            InitButtons();
        }

        private void UnSubscribeButtons()
        {
            _uiPlayingWindow.Buttons[0].OnClick -= ShowPauseWindow;
        }

        private void InitButtons()
        {
            _uiPlayingWindow.Buttons[0].OnClick += ShowPauseWindow;
        }

        private void ShowPauseWindow()
        {
            _uiService.Hide<UIPlayingWindowView>();
        }
    }
}