using Zenject;

namespace Money
{
    public class MoneyInstaller: Installer<MoneyInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<MoneyConfig>()
                .FromScriptableObjectResource("MoneyConfig")
                .AsSingle()
                .NonLazy();
        
            Container
                .Bind<MoneyController>()
                .AsSingle();
        }
    }
}