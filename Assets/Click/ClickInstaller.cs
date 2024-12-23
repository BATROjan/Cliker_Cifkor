﻿using Constantces;
using Zenject;

namespace Click
{
    public class ClickInstaller : Installer<ClickInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ClickConfig>()
                .FromScriptableObjectResource(ResourcesConst.ClickConfig)
                .AsSingle()
                .NonLazy();
            
            Container
                .Bind<ClickController>()
                .AsSingle().NonLazy();
        }
    }
}