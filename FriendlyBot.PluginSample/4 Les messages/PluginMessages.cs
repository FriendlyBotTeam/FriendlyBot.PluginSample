﻿using FriendlyBot.API.Accounts;
using FriendlyBot.API.Attributes;
using FriendlyBot.API.PluginsInterfaces;

[assembly: Plugin(typeof(FriendlyBot.PluginSample.PluginMessages), FriendlyBot.API.Enums.PluginType.DofusApiPlugin, "Mon premier plugin Friendlybot qui utilise les packets", "Exemple par Nicogo", "Pseudo")]

namespace FriendlyBot.PluginSample
{
    class PluginMessages : IUnloadable
    {
        private IDofusAccount _dofusAccount;
        PluginMessages(IDofusAccount dofusAccount)
        {
            _dofusAccount = dofusAccount;
            _dofusAccount.DofusBotManager.Logger.Add($"Salut {dofusAccount.FriendlyAccount.Username}, tu es connecter en {dofusAccount.DofusBotManager.ConnectionType}!", FriendlyBot.API.Enums.LogType.Debug);
        }
        public void Unload()
        {
            _dofusAccount.DofusBotManager.Logger.Add($"a++ {_dofusAccount.FriendlyAccount.Username} :(", FriendlyBot.API.Enums.LogType.Debug);
            _dofusAccount = null;
        }

        #region Messages handler

        [Message(typeof(FriendlyBot.API.DofusMessages.Game.Chat.IChatErrorMessage))] //permet à Friendlybot de savoir quel packet vous voulez attendre
        public void HandleChatErrorMessage(FriendlyBot.API.DofusMessages.Game.Chat.IChatErrorMessage packet, FriendlyBot.API.MessageEvent e)
        //l'argument "packet" du type INetworkMessage (ou du packet que vous attendez) contient toutes les données relative au packet "deserializé".
        //le e de trype MessageEvent contient les informations de provenances et de destination du packet, les données brutes ainsi que la possibilité d'annuler le packet à l'aide de la property "Cancel"
        {
            _dofusAccount.DofusBotManager.Logger.Add("Erreur : " + ((FriendlyBot.API.DofusEnums.ChatErrorEnum)packet.Reason).ToString(), FriendlyBot.API.Enums.LogType.ChannelGlobal);
        }

        #endregion

        #region Function

        public void SendPrivateMessage(string receiver, string content)
        {
            var message = new ChatClientPrivateMessage(); //on créer une instance du packet à envoyer
            message.Receiver = new PlayerSearchCharacterNameInformation() { Name = receiver };
            message.Content = content;
            _dofusAccount.DofusBotManager.Send(message, FriendlyBot.API.Enums.SocketTarget.Server); //on l'envois au serveur
            //PS : Si vous utilisez SimpleAPI, envoyé le packet via MessageAPI.SendMessage();
            //Cette fonction va vérifié que vous être dans les bonnes conditions avant d'envoyé le packet (par exemple, il faut être en combat avant de lancé un sort, ...)
        }
        public class ChatClientPrivateMessage : FriendlyBot.API.DofusMessages.Game.Chat.IChatClientPrivateMessage //on défini notre packet à l'aide de l'interface du packet à envoyer.
        {
            public int ProtocolId { get; } //fixé par friendlybot
            public string Content { get; set; } //le texte du message
            public API.DofusTypes.Common.IAbstractPlayerSearchInformation Receiver { get; set; }//le destinataire
        }
        public class AbstractPlayerSearchInformation : API.DofusTypes.Common.IAbstractPlayerSearchInformation
        {
            public int ProtocolId { get; } //fixé par friendlybot
        }
        public class PlayerSearchCharacterNameInformation : API.DofusTypes.Common.IPlayerSearchCharacterNameInformation //maybe it's false, need to check
        {
            public int ProtocolId { get; } //fixé par friendlybot

            public string Name { get; set; } //le nom du joueur
        }
        
        #endregion
    }
}
