using Gui.MainWindow;
using Infrastructure.Services.WindowService;

namespace Infrastructure
{
    public class App
    {
        private CompositionRoot _compositionRoot;
        
        public App()
        {
            _compositionRoot = new CompositionRoot();
            
            CompositionRoot.Single<IWindowService>()
                .ShowWindow<MainWindowPresenter>();
        }
    }
}