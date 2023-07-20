using UnityEngine;

namespace Infrastructure.Services.WindowService
{
    public interface IWindowService : IService
    {
        void ShowWindow<TPresenter>() where TPresenter : WindowPresenter;
    }
}