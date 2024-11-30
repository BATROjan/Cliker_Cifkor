using UI.UIPlayingWindow;
using UI.UIService;
using Zenject;

namespace UI
{
    public class UIRootInstaller : Installer<UIRootInstaller>
    {
        public override void InstallBindings()
        {
            UIPlayingWindowInstaller
                .Install(Container);

            Container.Bind<IUIRoot>()
                .FromComponentInNewPrefabResource("UIRoot")
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IUIService>()
                .To<UIService
                    .UIService>()
                .AsSingle()
                .NonLazy();
        }
    }
}