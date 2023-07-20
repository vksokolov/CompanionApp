using Cysharp.Threading.Tasks;
using Infrastructure.Services.AssetProvider;
using Infrastructure.Services.WindowService;

namespace Gui.MainWindow
{
    public class MainWindowPresenter : WindowPresenter<MainWindowView>
    {
        private readonly MainWindowView _view;

        public MainWindowPresenter(MainWindowView view) : base(view)
        {
            _view = view;
        }

        public override void Show()
        {
            _view.AppIcon.LoadIconAsync().Forget();
            base.Show();
        }

        public override async UniTask Prewarm()
        {
            await _view.AppIcon.LoadIconAsync();
        }
    }
}