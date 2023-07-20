using Infrastructure.Services.AssetProvider;
using UnityEngine;
using Utils;
using Utils.Attributes;

namespace Gui.Elements
{
    [DefaultPrefab("Prefabs/LoadingSpinner")]
    public class LoadingSpinner : MonoBehaviour
    {
        private static GameObjectPool<LoadingSpinner> _pool = new();

        public static void SetAssetProvider(IAssetProvider assetProvider) =>
            _pool = new GameObjectPool<LoadingSpinner>(assetProvider);

        public static LoadingSpinner GetSpinner(Transform root)
        {
            var spinner = _pool.Get();
            spinner.transform.SetParent(root, false);

            return spinner;
        }

        public void Release() => 
            _pool.Release(this);
    }
}