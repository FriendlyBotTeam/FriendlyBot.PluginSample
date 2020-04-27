using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FriendlyBot.PluginSample.Views
{
    public class ContentView : UserControl
    {
        public ContentView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
