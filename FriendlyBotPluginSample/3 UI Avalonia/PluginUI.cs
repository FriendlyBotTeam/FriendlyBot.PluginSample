using FriendlyBot.API;
using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;
using FriendlyBot.API.Enums;
using FriendlyBot.API.Managers.Core.Basic.Actions;
using FriendlyBot.API.PluginsInterfaces;
using FriendlyBotPluginSample.ViewModels;

[assembly: Plugin(typeof(FriendlyBotPluginSample.UIExample), PluginType.DofusBotPlugin, "UI Plugin Sample", "Mon premier plugin avec UI avalonia", "Nicogo")]

namespace FriendlyBotPluginSample
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
        private IScheduledSynchronizedAction _loop = null;

        UIExample(IDofusAccount dofusAccount)
        {
            _dofusAccount = dofusAccount;
            _dofusAccount.DofusBotManager.Logger.Add($"Salut {dofusAccount.FriendlyAccount.Username}, tu a activé le plugin UI avalonia !", LogType.Debug);

            _headerViewModel = new HeaderViewModel();
            _contentViewModel = new ContentViewModel();

            _tabItemDefinition = new TabItemDefinition(this, _headerViewModel, _contentViewModel);
            _dofusAccount.BotManager.AddTabControl(_tabItemDefinition);

            _loop = dofusAccount.DofusBotManager.ActionsManager.Schedule(Update, 5000, true);
        }

        private void Update()
        {
            _headerViewModel.Text = (++_counter).ToString();
            _contentViewModel.Data.Add("ok ok : " + _counter.ToString());
            _contentViewModel.DataWtf.Add(new HeaderViewModel() { Text = _counter.ToString() });
        }

        public void Unload()
        {
            _loop.Cancel = true;
            _loop = null;
            _dofusAccount.BotManager.RemoveTabControl(_tabItemDefinition);

            _dofusAccount.DofusBotManager.Logger.Add($"A + {_dofusAccount.FriendlyAccount.Username} !", LogType.Debug);
            _dofusAccount = null;
        }

        #endregion

        #region Functions


        #endregion
    }
}
