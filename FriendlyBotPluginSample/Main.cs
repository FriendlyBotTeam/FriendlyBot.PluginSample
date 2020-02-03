using System.Collections.Generic;
using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;
using FriendlyBot.API.Enums;
using FriendlyBot.API.PluginsInterfaces;


//Il éxiste 4 types de plugins :
//FriendlyPlugin - Plugin lié à FriendlyBot
//DofusBotPlugin - Plugin lié à un Compte Dofus
//DofusApiPlugin - Plugin lié à un Compte Dofus, chargé automatiquement au chargement du compte
//DofusUtilsPlugin - Plugin lié à un Compte Dofus, chargé automatiquement au chargement du compte et non visible dans la liste des plugins (à utiliser pour les sous plugins)

//exemples : SimpleAPI est un ApiPlugin, MapAPI est un UtilsPlugin, la Console principale est un FriendlyPlugin, l'autre un BotPlugin.

[assembly: Plugin(typeof(FriendlyBotPluginSample.MyFirstFriendlyPlugin), FriendlyBot.API.Enums.PluginType.FriendlyPlugin, "Mon premier plugin Friendlybot", "Plugin de ...", "Pseudo")]
[assembly: Plugin(typeof(FriendlyBotPluginSample.MyFirstAPIPlugin), FriendlyBot.API.Enums.PluginType.DofusApiPlugin, "Mon premier plugin API", "Plugin de ...", "Pseudo")]
[assembly: Plugin(typeof(FriendlyBotPluginSample.MyFirstBotPlugin), FriendlyBot.API.Enums.PluginType.DofusBotPlugin, "Mon premier plugin normal", "Plugin de ...", "Pseudo")]
[assembly: Plugin(typeof(FriendlyBotPluginSample.MyFirstBotPluginWithUnloadable), FriendlyBot.API.Enums.PluginType.DofusBotPlugin, "Mon premier plugin normal unloadable", "Plugin de ...", "Pseudo")]

namespace FriendlyBotPluginSample
{
    class MyFirstFriendlyPlugin
    {

        MyFirstFriendlyPlugin(IFriendlyAccount friendlyAccount) //Un FriendlyPlugin doit avoir en argument de constructeur IFriendlyAccount
        {
            friendlyAccount.FriendlyBotManager.Logger.Add("Mon premier Log dans FriendlyBot", LogType.Debug); //petit log indiquant que le plugin est charger
        }
    }
    class MyFirstAPIPlugin 
    {
        private readonly IDofusAccount _dofusAccount;
        MyFirstAPIPlugin(IDofusAccount dofusAccount)
        {
            _dofusAccount = dofusAccount;
            dofusAccount.BotManager.Logger.Add("Mon premier Log avec une API", LogType.Debug);
        }

        public void Test()
        {
            _dofusAccount.BotManager.Logger.Add("Test from " + ToString(), LogType.Debug);
        }
    }

    class MyFirstBotPlugin 
    {
        MyFirstBotPlugin(IDofusAccount dofusAccount)
        {
            dofusAccount.BotManager.Logger.Add("Mon premier Log avec un plugin", LogType.Debug);
            dofusAccount.DofusBotManager.GetPlugin<MyFirstAPIPlugin>().Test();

            var _JobToGatheredRessources = new Dictionary<string, List<int>>();

            foreach (var entry in _JobToGatheredRessources)
            {
                foreach (var ressourceId in entry.Value)
                {
                    System.Console.WriteLine("Key = {0}, Value = {1}", entry.Key, ressourceId);
                }
            }

        }
    }

    class MyFirstBotPluginWithUnloadable : IUnloadable
    {
        private readonly IDofusAccount _dofusAccount;
        MyFirstBotPluginWithUnloadable(IDofusAccount dofusAccount)
        {
            _dofusAccount = dofusAccount;
            dofusAccount.BotManager.Logger.Add("Mon premier Log avec un plugin", LogType.Debug);
        }

        public void Unload()
        {
            _dofusAccount.BotManager.Logger.Add("je suis unload :(", LogType.Debug);
        }
    }
}