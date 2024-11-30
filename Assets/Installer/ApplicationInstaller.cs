using AudioController;
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
            
            AudioInstaller
                .Install(Container);
        }
    }
}