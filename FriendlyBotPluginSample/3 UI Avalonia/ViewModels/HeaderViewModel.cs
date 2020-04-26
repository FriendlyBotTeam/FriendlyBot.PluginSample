using ReactiveUI;

namespace FriendlyBot.PluginSample.ViewModels
{
    public class HeaderViewModel : ReactiveObject
    {

        private string _text = "Coucou ! ";

        public string Text { get => _text; set => this.RaiseAndSetIfChanged(ref _text, value); }


    }
}
