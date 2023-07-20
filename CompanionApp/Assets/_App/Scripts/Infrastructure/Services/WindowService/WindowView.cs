using System;
using UnityEngine;

namespace Infrastructure.Services.WindowService
{
    public abstract class WindowView : MonoBehaviour, IDisposable, IWindowView
    {
        public GameObject GameObject => gameObject;
        public abstract void Dispose();
    }
}