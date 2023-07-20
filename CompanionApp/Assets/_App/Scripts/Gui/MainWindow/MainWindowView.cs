using Gui.Elements;
using Infrastructure.Services.WindowService;
using Utils.Attributes;

namespace Gui.MainWindow
{
    [DefaultPrefab("Windows/MainWindow")]
    public class MainWindowView : WindowView
    {
        public SpriteLoader AppIcon;
        
        public override void Dispose()
        {
        }
    }
}