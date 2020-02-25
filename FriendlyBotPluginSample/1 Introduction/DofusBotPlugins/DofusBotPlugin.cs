using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;
using System.Collections.Generic;

[assembly: Plugin(typeof(FriendlyBotPluginSample.DofusBotPlugins.DofusBotPlugin), FriendlyBot.API.Enums.PluginType.DofusBotPlugin, "Mon premier plugin Friendlybot (dofus)", "Exemple par Nicogo", "Pseudo")]

namespace FriendlyBotPluginSample.DofusBotPlugins
{
    class DofusBotPlugin //Plugin pouvant être charger uniquement depuis l'onglet "Plugins" des comptes dofus. Il apparait en vert. C'est le plugin le plus utilisé étant donné qu'il permet la réalisation d'actions lié à un compte dofus connecté avec le bot.
    {
        DofusBotPlugin(IDofusAccount dofusAccount)
        {
            dofusAccount.DofusBotManager.Logger.Add($"Salut {dofusAccount.FriendlyAccount.Username}, tu es connecter en {dofusAccount.DofusBotManager.ConnectionType}!", FriendlyBot.API.Enums.LogType.Debug);
        }
    }
}
