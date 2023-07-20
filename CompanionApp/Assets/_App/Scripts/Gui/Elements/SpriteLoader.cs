using System;
using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetProvider;
using UnityEngine;
using UnityEngine.UI;

namespace Gui.Elements
{
    [RequireComponent(typeof(Image))]
    public class SpriteLoader : MonoBehaviour
    {
        private static IAssetProvider _assetProvider;
        
        private Image _image;
        public string SpriteName;

        private LoadingSpinner _loadingSpinner;

        public async UniTask LoadIconAsync()
        {
            _image ??= GetComponent<Image>();
            _image.enabled = false;

            _loadingSpinner = LoadingSpinner.GetSpinner(_image.transform);
            _image.sprite = await _assetProvider.LoadAsync<Sprite>(SpriteName);
            _image.enabled = true;
            
            _loadingSpinner.Release();
        }

        public void LoadIcon(IAssetProvider assetProvider)
        {
            _image ??= GetComponent<Image>();
            _image.sprite = _assetProvider.Load<Sprite>(SpriteName);
        }

        public static void SetAssetProvider(IAssetProvider assetProvider) =>
            _assetProvider = assetProvider;
    }
}