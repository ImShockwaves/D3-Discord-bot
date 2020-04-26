# D3-Discord-Bot
A Discord bot to get and display data about Diablo 3

In order to use this bot locally you will need credentials from discord and battle.net (as you may guess, I will not share mine).
You will need to setup new environment variables: 
- **BOT_TOKEN** that you have to retrieve from discord developer portal
- **BOT_PREFIX** is the prefix before each commands (ex: ***!profile battletag region***, here "!" is the prefix)
- **B_CLIENT** is the client id that you have to retrieve from battle.net developer portal
- **B_SECRET** is the client id that you have to retrieve from battle.net developer portal

Here is a template of what you can do to set it up, for example in *Properties/launchSettings.json*:
```json
{
  "iisSettings": {
    "windowsAuthentication": false, 
    "anonymousAuthentication": true, 
    "iisExpress": {
      "applicationUrl": "http://localhost:48112",
      "sslPort": 44325
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "d3bot": {
      "commandName": "Project",
      "launchBrowser": true,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "B_CLIENT": "YourBattleNetClientId",
        "B_SECRET": "YourBattleNetSecretId",
        "BOT_TOKEN":  "YourBotToken",
        "BOT_PREFIX": "!",
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```
