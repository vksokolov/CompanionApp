using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Gui.MainWindow;
using UnityEngine;

namespace Infrastructure.Services.WindowService
{
    public class WindowService : IWindowService
    {
        private readonly IWindowFactory _windowFactory;
        private readonly Canvas _canvas;
        private readonly Dictionary<Type, Func<ITypedWindowPresenter<IWindowView>>> _windowConstructors;
        private readonly Dictionary<Type, ITypedWindowPresenter<IWindowView>> _createdWindows;
        private readonly Stack<ITypedWindowPresenter<IWindowView>> _openedWindows = new();

        public WindowService(IWindowFactory windowFactory)
        {
            _windowFactory = windowFactory;
            _windowConstructors = new();
            _createdWindows = new();

            _canvas = _windowFactory.CreateCanvas();
            
            _windowConstructors.Add(typeof(MainWindowPresenter), CreateMainWindow);
        }

        public void Dispose()
        {
            while (_openedWindows.TryPop(out var window))
                window.HideAndUnload().Forget();
        }

        public void ShowWindow<TPresenter>() where TPresenter : WindowPresenter
        {
            var window = GetWindowPresenter<TPresenter>();
            window.Show();
        }
        
        public async UniTask ShowWindowAsync<TPresenter>() where TPresenter : WindowPresenter
        {
            var window = GetWindowPresenter<TPresenter>();
            await window.PrewarmAndShow();
        }

        private IWindowPresenter GetWindowPresenter<TPresenter>() where TPresenter : WindowPresenter
        {
            if (_createdWindows.TryGetValue(typeof(TPresenter), out var windowPresenter)) 
                return windowPresenter;

            if (!_windowConstructors.TryGetValue(typeof(TPresenter), out var createWindow))
                throw new Exception($"Constructor for {nameof(TPresenter)} window view not registered");

            windowPresenter = createWindow();
            _createdWindows.Add(typeof(TPresenter), windowPresenter);

            return windowPresenter;
        }

        private MainWindowPresenter CreateMainWindow()
        {
            var view = _windowFactory.CreateWindow<MainWindowView>(_canvas.transform);
            var presenter = new MainWindowPresenter(view);
            return presenter;
        }
    }
}