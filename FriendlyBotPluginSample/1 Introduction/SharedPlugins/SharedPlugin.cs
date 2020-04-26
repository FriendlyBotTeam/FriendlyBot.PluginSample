using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;

[assembly: Plugin(typeof(FriendlyBot.PluginSample.SharedPlugin), FriendlyBot.API.Enums.PluginType.FriendlyPlugin, "Mon premier plugin partager Friendlybot (Faccount)", "Exemple par Nicogo", "Nicogo")]
[assembly: Plugin(typeof(FriendlyBot.PluginSample.SharedPlugin), FriendlyBot.API.Enums.PluginType.DofusBotPlugin, "Mon premier plugin partager Friendlybot (Daccount)", "Exemple par Nicogo", "Nicogo")]

namespace FriendlyBot.PluginSample
{
    class SharedPlugin //Plugin pouvant être charger depuis l'onglet principal "Plugins" ainsi que depuis chaque compte dofus. Il apparait en noir (FbPlugin) et vert (DbPlugin).
    {
        private SharedPlugin(IAccountBase account)
        {
            string name = "unknown";
            string accountSource = "unknown";

            if (account is IFriendlyAccount fAccount)
            {
                name = fAccount.Username;
                accountSource = "FriendlyBot <3";
            }
            else if (account is IDofusAccount dAccount)
            {
                name = dAccount.FriendlyAccount.Username;
                accountSource = "Dofus <3";
            }

            account.BotManager.Logger.Add($"Salut {name}, tu m'as charger à partir de ton compte {accountSource}!", FriendlyBot.API.Enums.LogType.Debug);
        }
    }
}
