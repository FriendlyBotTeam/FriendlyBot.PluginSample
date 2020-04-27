using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;

[assembly: Plugin(typeof(FriendlyBot.PluginSample.DofusUtilsOuAPIPlugin), FriendlyBot.API.Enums.PluginType.DofusApiPlugin, "Mon premier plugin Friendlybot API (dofus)", "Exemple par Nicogo", "Pseudo")]
//[assembly: Plugin(typeof(FriendlyBotPluginSample.DofusUtilsOuAPIPlugin), FriendlyBot.API.Enums.PluginType.DofusUtilsPlugin, "Mon premier plugin Friendlybot Utils (dofus)", "Exemple par Nicogo", "Pseudo")]

namespace FriendlyBot.PluginSample
{
    class DofusUtilsOuAPIPlugin //Plugin charger automatiquement par le bot au chargement d'un compte. Il apparait en vert clair (API) ou n'est pas visible dans la liste des plugins d'un compte dofus (Utils) (vert très clair dans l'onglet "plugins" principal). Ce plugin à pout but d'être utiliser par d'autres plugins afin de simplifié ou d'ajouté des fonctionalités à son plugin !
    {
        DofusUtilsOuAPIPlugin(IDofusAccount dofusAccount)
        {
            dofusAccount.DofusBotManager.Logger.Add($"Salut {dofusAccount.FriendlyAccount.Username}, tu es connecter en {dofusAccount.DofusBotManager.ConnectionType}!", FriendlyBot.API.Enums.LogType.Debug);
        }
    }
}
