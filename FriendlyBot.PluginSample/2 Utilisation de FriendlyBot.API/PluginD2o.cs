using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;

[assembly: Plugin(typeof(FriendlyBot.PluginSample.PluginD2o), FriendlyBot.API.Enums.PluginType.DofusBotPlugin, "Mon premier plugin Friendlybot D2o", "Exemple par Nicogo", "Pseudo")]

namespace FriendlyBot.PluginSample
{
    class PluginD2o //Tout les plugins Peuvent utiliser les D2o, ce sont toutes les données de dofus.
    {

        private IDofusAccount _dofusAccount;

        PluginD2o(IDofusAccount dofusAccount)
        {
            _dofusAccount = dofusAccount;

            //Vous pouvez récup un D2o avec la fonction suivante et l'ID du D2o :
            int itemId = 1112;
            var item = _dofusAccount.FriendlyAccount.FriendlyBotManager.D2o.GetData<FriendlyBot.API.DofusDatas.Item>(itemId);

            //pour avoir les "texts" (I18N, voir google) :
            var itemName = _dofusAccount.FriendlyAccount.FriendlyBotManager.I18n.GetText(item.NameId);
            var itemdescription = _dofusAccount.FriendlyAccount.FriendlyBotManager.I18n.GetText(item.DescriptionId);

            //Vous pouvez récup tous les D2o d'un type avec : (attention, fonction lente)
            var items = _dofusAccount.FriendlyAccount.FriendlyBotManager.D2o.GetDatas<FriendlyBot.API.DofusDatas.Item>();
        }

        public void Unload()
        {
            _dofusAccount = null;
        }

    }
}
