using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;
using System.Linq;

[assembly: Plugin(typeof(FriendlyBotPluginSample.FriendlyPlugin), FriendlyBot.API.Enums.PluginType.FriendlyPlugin, "Mon premier plugin Friendlybot", "Exemple par Nicogo", "Nicogo")]

namespace FriendlyBotPluginSample
{
    class FriendlyPlugin //Plugin pouvant être charger uniquement depuis l'onglet principal "Plugins". Il apparait en noir et permet la gestion et l'automatisation de FriendlyBot ainsi que des bots.
    {
        private FriendlyPlugin(IFriendlyAccount friendlyAccount)
        {
            friendlyAccount.FriendlyBotManager.Logger.Add($"Salut {friendlyAccount.Username}, il y a actuellement {friendlyAccount.FriendlyBotManager.ConnectedAccounts.Count()} comptes connecté !", FriendlyBot.API.Enums.LogType.Debug);
        }
    }
}
