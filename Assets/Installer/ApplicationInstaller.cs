using AudioController;
using Click;
using Energy;
using Money;
using UI;
using Zenject;

namespace Installer
{
    public class ApplicationInstaller : MonoInstaller<ApplicationInstaller>
    {
        public override void InstallBindings()
        {
            CameraInstaller
                .CameraInstaller
                .Install(Container);

            UIRootInstaller
                .Install(Container);
            
            MoneyInstaller
                .Install(Container);

            ClickInstaller
                .Install(Container);

            EnergyInstaller
                .Install(Container);

            Container
                .Bind<GameController.GameController>()
                .AsSingle().NonLazy();

            AudioInstaller
                .Install(Container);
        }
    }
}