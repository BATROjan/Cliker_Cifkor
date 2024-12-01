using Zenject;

namespace Click
{
    public class ClickInstaller : Installer<ClickInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ClickController>()
                .AsSingle().NonLazy();
        }
    }
}