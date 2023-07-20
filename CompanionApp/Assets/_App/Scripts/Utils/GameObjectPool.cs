using System.Collections.Generic;
using Infrastructure.Services.AssetProvider;
using UnityEngine;

namespace Utils
{
    public class GameObjectPool<T> where T : Component
    {
        private readonly IAssetProvider _assetProvider;
        private readonly Stack<T> _pool = new();

        private static Transform _objectKeeper;
        private static Transform ObjectKeeper
        {
            get
            {
                if (_objectKeeper == null)
                {
                    _objectKeeper = new GameObject("Pool").GetComponent<Transform>();
                    _objectKeeper.gameObject.SetActive(false);
                }

                return _objectKeeper;
            }
        }

        public GameObjectPool(IAssetProvider assetProvider = null)
        {
            _assetProvider = assetProvider;
        }
        
        public T Get()
        {
            if (!_pool.TryPop(out var obj))
                obj = Instantiate();

            return obj;
        }

        public void Release(T obj)
        {
            obj.transform.SetParent(_objectKeeper);
            _pool.Push(obj);
        }

        private T Instantiate()
        {
            return _assetProvider != null 
                ? _assetProvider.Instantiate<T>() 
                : new GameObject(nameof(T)).AddComponent<T>();
        }
    }
}