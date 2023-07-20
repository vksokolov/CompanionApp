using Cysharp.Threading.Tasks;

namespace Infrastructure.Services.WindowService
{
    public interface ITypedWindowPresenter<out TView> : IWindowPresenter where TView : IWindowView
    {
        TView TypedView { get; }
    }
    
    public interface IWindowPresenter
    {
        IWindowView View { get; }
        UniTask PrewarmAndShow();
        UniTask Prewarm();
        void Show();
        UniTask HideAndUnload();
        void Hide();
        UniTask Unload();
    }
}