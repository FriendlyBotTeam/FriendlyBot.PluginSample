using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FriendlyBotPluginSample.Views
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
