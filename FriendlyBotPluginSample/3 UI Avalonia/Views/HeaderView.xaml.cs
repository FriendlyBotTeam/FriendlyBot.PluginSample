using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace FriendlyBotPluginSample.Views
{
    public class HeaderView : UserControl
    {
        public HeaderView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
