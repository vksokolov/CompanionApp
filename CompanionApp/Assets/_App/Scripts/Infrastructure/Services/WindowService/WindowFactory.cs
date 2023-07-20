using Infrastructure.Services.AssetProvider;
using UnityEngine;

namespace Infrastructure.Services.WindowService
{
    public class WindowFactory : IWindowFactory
    {
        private const string CanvasPrefabPath = "Prefabs/Canvas";
        private readonly IAssetProvider _assetProvider;

        public WindowFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public Canvas CreateCanvas() => 
            _assetProvider.Instantiate(CanvasPrefabPath).GetComponent<Canvas>();

        public TView CreateWindow<TView>(Transform root) where TView : WindowView
        {
            return _assetProvider.Instantiate<TView>(root);
        }
    }
}