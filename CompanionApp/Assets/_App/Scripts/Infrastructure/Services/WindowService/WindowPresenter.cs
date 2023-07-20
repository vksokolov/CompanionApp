using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Infrastructure.Services.WindowService
{
    public abstract class WindowPresenter<TView> : WindowPresenter, ITypedWindowPresenter<TView> 
        where TView : IWindowView
    {
        public TView TypedView { get; }

        protected WindowPresenter(TView view) : base(view)
        {
            TypedView = view;
        }
    }

    public abstract class WindowPresenter : IWindowPresenter
    {
        public IWindowView View { get; }

        protected WindowPresenter(IWindowView view)
        {
            View = view;
        }
        
        public virtual async UniTask PrewarmAndShow()
        {
            await Prewarm();
            Show();
        }

        public virtual UniTask Prewarm() => 
            UniTask.CompletedTask;

        public virtual void Show() => 
            View.GameObject.SetActive(true);

        public virtual async UniTask HideAndUnload()
        {
            Hide();
            await Unload();
        }

        public virtual void Hide() => 
            View.GameObject.SetActive(false);

        public virtual UniTask Unload() => 
            UniTask.CompletedTask;
    }
}