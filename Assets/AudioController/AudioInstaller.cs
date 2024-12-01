using Constantces;
using Zenject;

namespace AudioController
{
    public class AudioInstaller : Installer<AudioInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<AudioModelConfig>()
                .FromScriptableObjectResource(ResourcesConst.AudioModelConfig)
                .AsSingle()
                .NonLazy();
        
            Container
                .BindMemoryPool<AudioView, AudioView.Pool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefabResource(ResourcesConst.AudioView)
                .UnderTransformGroup(ResourcesConst.AudioViewGroup);
        
            Container
                .Bind<AudioController>()
                .AsSingle();
        }
    }
}