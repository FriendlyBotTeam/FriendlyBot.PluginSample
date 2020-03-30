using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;

[assembly: Plugin(typeof(FriendlyBotPluginSample.PluginD2o), FriendlyBot.API.Enums.PluginType.DofusBotPlugin, "Mon premier plugin Friendlybot D2o", "Exemple par Nicogo", "Pseudo")]

namespace FriendlyBotPluginSample
{
    class PluginD2o //Tout les plugins Peuvent utiliser les D2o, ce sont toutes les données de dofus.
    {

        private IDofusAccount _dofusAccount;

        PluginD2o(IDofusAccount dofusAccount)
        {
            _dofusAccount = dofusAccount;

            //Vous pouvez récup un D2o avec la fonction suivante et l'ID du D2o :
            int itemId = 0;
            var item = _dofusAccount.FriendlyAccount.FriendlyBotManager.D2o.GetData<FriendlyBot.API.DofusDatas.Item>(itemId);


            //Vous pouvez récup tous les D2o d'un type avec : (attention, fonction lente)
            var items = _dofusAccount.FriendlyAccount.FriendlyBotManager.D2o.GetDatas<FriendlyBot.API.DofusDatas.Item>();
        }

        public void Unload()
        {
            _dofusAccount = null;
        }

    }
}
