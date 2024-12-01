using Constantces;
using Zenject;

namespace Energy
{
    public class EnergyInstaller: Installer<EnergyInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<EnergyConfig>()
                .FromScriptableObjectResource(ResourcesConst.EnergyConfig)
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<EnergyController>()
                .AsSingle().NonLazy();
        }
    }
}