using FriendlyBot.API;
using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;
using FriendlyBot.API.Enums;
using FriendlyBot.API.PluginsInterfaces;
using FriendlyBot.PluginSample.ViewModels;
using System.Threading.Tasks;

[assembly: Plugin(typeof(FriendlyBot.PluginSample.UIExample), PluginType.DofusBotPlugin, "UI Plugin Sample", "Mon premier plugin avec UI avalonia", "Nicogo")]

namespace FriendlyBot.PluginSample
{
    internal class UIExample : IUnloadable
    {
        #region Vars

        private HeaderViewModel _headerViewModel;
        private ContentViewModel _contentViewModel;
        private TabItemDefinition _tabItemDefinition;

        #endregion

        #region Plugin

        private IDofusAccount _dofusAccount;
        private int _counter = 0;

        UIExample(IDofusAccount dofusAccount)
        {
            _dofusAccount = dofusAccount;
            _dofusAccount.DofusBotManager.Logger.Add($"Salut {dofusAccount.FriendlyAccount.Username}, tu a activé le plugin UI avalonia !", LogType.Debug);

            _headerViewModel = new HeaderViewModel();
            _contentViewModel = new ContentViewModel();

            _tabItemDefinition = new TabItemDefinition(this, _headerViewModel, _contentViewModel);
            _dofusAccount.BotManager.AddTabControl(_tabItemDefinition);

            Update();
        }

        private async void Update()
        {
            while (_dofusAccount != null)
            {
                _headerViewModel.Text = (++_counter).ToString();
                _contentViewModel.Data.Add("ok ok : " + _counter.ToString());
                _contentViewModel.DataWtf.Add(new HeaderViewModel() { Text = _counter.ToString() });
                await Task.Delay(1000);
            }
        }

        public void Unload()
        {
            _dofusAccount.BotManager.RemoveTabControl(_tabItemDefinition);
            _dofusAccount.DofusBotManager.Logger.Add($"A + {_dofusAccount.FriendlyAccount.Username} !", LogType.Debug);
            _dofusAccount = null;
        }

        #endregion

        #region Functions


        #endregion
    }
}
