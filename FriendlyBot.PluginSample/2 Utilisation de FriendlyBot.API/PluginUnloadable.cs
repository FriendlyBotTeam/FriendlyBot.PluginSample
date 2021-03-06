﻿using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;
using FriendlyBot.API.PluginsInterfaces;

[assembly: Plugin(typeof(FriendlyBot.PluginSample.PluginUnloadable), FriendlyBot.API.Enums.PluginType.DofusBotPlugin, "Mon premier plugin Friendlybot Unloadable", "Exemple par Nicogo", "Pseudo")]

namespace FriendlyBot.PluginSample
{
    class PluginUnloadable : IUnloadable //Tout les plugins friendlyBot peuvent implémenté l'interface "IUnloadable".
    {

        private IDofusAccount _dofusAccount;

        PluginUnloadable(IDofusAccount dofusAccount)
        {
            _dofusAccount = dofusAccount;
            _dofusAccount.DofusBotManager.Logger.Add($"Salut {dofusAccount.FriendlyAccount.Username}, tu es connecter en {dofusAccount.DofusBotManager.ConnectionType}!", FriendlyBot.API.Enums.LogType.Debug);
        }

        public void Unload()
        {
            _dofusAccount.DofusBotManager.Logger.Add($"a++ {_dofusAccount.FriendlyAccount.Username} :(", FriendlyBot.API.Enums.LogType.Debug);
            _dofusAccount = null;
        }

    }
}
