using UnityEngine;

namespace Infrastructure.Services.WindowService
{
    public interface IWindowFactory
    {
        TView CreateWindow<TView>(Transform root) where TView : WindowView;
        Canvas CreateCanvas();
    }
}