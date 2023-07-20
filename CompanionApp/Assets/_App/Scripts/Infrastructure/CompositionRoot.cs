using System;
using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.AssetProvider;

namespace Infrastructure
{
    public class CompositionRoot
    {
        public CompositionRoot()
        {
            RegisterSingle(new AssetProvider());
        }

        private void RegisterSingle<TService>(TService implementation) where TService : IService => 
            Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService => 
            Implementation<TService>.ServiceInstance;

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}