# FriendlyBot.PluginSample ![.NET Core Release](https://github.com/FriendlyBotTeam/FriendlyBot.Plugins/workflows/.NET%20Core%20Release/badge.svg)

FriendlyBot.PluginSample est un projet contenant différents exemple de création de plugin.

Afin de pouvoir créer votre plugin, 2 options s'offrent à vous.

Sois, de manière idépendante, vous configuré votre projet pour qu'il fasse référence à FriendlyBot.api.dll,
Que les résultats de build se trouve dans le dossier "Plugins" de FriendlyBot
et (optionel) quand vous debugger, Visual lance automatiquement FriendlyBot en mode Debug afin de pouvoir débugger votre plugin.

Sois, vous devez demander le role de Développeur de plugin sur le site de FriendlyBot.
Vous devez ensuite le cloné dans un dossier nomé "FriendlyBotDev" situé à coté de l'éxécutable du Launcher.
Et vous devez télécharger la version Développeur de FriendlyBot via le launcher.
