using System;
using System.Collections.Generic;
using Gui.Elements;
using Infrastructure.Services;
using Infrastructure.Services.AssetProvider;
using Infrastructure.Services.WindowService;

namespace Infrastructure
{
    public class CompositionRoot
    {
        public CompositionRoot()
        {
            var assetProvider = new AssetProvider();
            RegisterSingle<IAssetProvider>(assetProvider);

            LoadingSpinner.SetAssetProvider(assetProvider);
            SpriteLoader.SetAssetProvider(assetProvider);

            var windowFactory = new WindowFactory(assetProvider);
            var windowService = new WindowService(windowFactory);
            RegisterSingle<IWindowService>(windowService);
        }

        private void RegisterSingle<TService>(TService implementation) where TService : IService => 
            Implementation<TService>.ServiceInstance = implementation;

        public static TService Single<TService>() where TService : IService => 
            Implementation<TService>.ServiceInstance;

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}