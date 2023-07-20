using UnityEngine;

namespace Infrastructure.Services.AssetProvider
{
    public interface IAssetProvider : IService
    {
        T Load<T>(string path, bool useDefaultIfNotFound = true) where T : Object;
        bool TryLoad<T>(string path, out T result) where T : Object;
        GameObject Instantiate(string path, Vector3 at, bool useDefaultIfNotFound = true);
        GameObject Instantiate(string path, bool useDefaultIfNotFound = true);
        T Instantiate<T>(Transform root = null, bool useDefaultIfNotFound = true) where T : Component;
    }
}