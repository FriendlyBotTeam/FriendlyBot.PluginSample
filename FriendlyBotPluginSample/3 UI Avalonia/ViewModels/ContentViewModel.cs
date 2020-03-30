using ReactiveUI;
using System.Collections.ObjectModel;

namespace FriendlyBotPluginSample.ViewModels
{
    public class ContentViewModel : ReactiveObject
    {

        private string _firstTabText = "A ! ";
        private string _secondTabText = "B ! ";
        private string _troisiemeTabText = "C ! ";

        public string FirstTabText { get => _firstTabText; set => this.RaiseAndSetIfChanged(ref _firstTabText, value); }
        public string SecondTabText { get => _secondTabText; set => this.RaiseAndSetIfChanged(ref _secondTabText, value); }
        public string TroisiemeTabText { get => _troisiemeTabText; set => this.RaiseAndSetIfChanged(ref _troisiemeTabText, value); }

        public ObservableCollection<string> Data { get; set; } = new ObservableCollection<string>(); // si tu fais une list de ViewModel, tu peux draw des ViewModel aussi, sinon c'est cast en string généralement
        public ObservableCollection<HeaderViewModel> DataWtf { get; set; } = new ObservableCollection<HeaderViewModel>(); // si tu fais une list de ViewModel, tu peux draw des ViewModel aussi, sinon c'est cast en string généralement

    }
}
