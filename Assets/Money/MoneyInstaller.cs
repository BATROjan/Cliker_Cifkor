using Constantces;
using Zenject;

namespace Money
{
    public class MoneyInstaller: Installer<MoneyInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<MoneyConfig>()
                .FromScriptableObjectResource(ResourcesConst.MoneyConfig)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindMemoryPool<MoneyView, MoneyView.Pool>()
                .FromComponentInNewPrefabResource(ResourcesConst.MoneyView);
        
            Container
                .Bind<MoneyController>()
                .AsSingle();
        }
    }
}