using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Utils.Attributes;
using Object = UnityEngine.Object;

namespace Infrastructure.Services.AssetProvider
{public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<Type, string> _defaultResourcePaths = new()
        {
            { typeof(Sprite), "Default/Sprite" },
            { typeof(DebugButton), "Default/DebugButton"}
        };
        
        public T Load<T>(string path, bool useDefaultIfNotFound = true) where T : Object
        {
            if (useDefaultIfNotFound)
                return TryLoad<T>(path, out var result) ? result : null;
            
            return Resources.Load<T>(path);
        }

        public bool TryLoad<T>(string path, out T result) where T : Object
        {
            result = Resources.Load<T>(path);
            if (result != null) return true;
            
            Debug.LogWarning($"Resource at path {path} not found, getting default resource...");
            
            if (_defaultResourcePaths.TryGetValue(typeof(T), out var defaultPath))
            {
                result = Resources.Load<T>(defaultPath);
                if (result == null) 
                    Debug.LogError("Default resource path for type " + typeof(T).Name + " is invalid");
            }
            else
                Debug.LogError("No default resource path specified for type " + typeof(T).Name);

            return result != null;
        }

        public GameObject Instantiate(string path, Vector3 at, bool useDefaultIfNotFound = true)
        {
            var prefab = Load<GameObject>(path, useDefaultIfNotFound);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }

        public GameObject Instantiate(string path, bool useDefaultIfNotFound = true)
        {
            var prefab = Load<GameObject>(path, useDefaultIfNotFound);
            return Object.Instantiate(prefab);
        }

        public T Instantiate<T>(Transform root, bool useDefaultIfNotFound = true) where T : Component
        {
            var attr = typeof(T).GetAttribute<DefaultPrefabAttribute>();
            var path = attr == null ? typeof(T).Name : attr.PrefabPath;
            
            var prefab = Load<T>(path, useDefaultIfNotFound);
            return Object.Instantiate(prefab, root);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}