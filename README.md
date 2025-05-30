Official post [here](https://community.koyeb.com/t/creating-an-rss-bot-for-discord/3728)

How to set up this discord bot with RSS feeds:
First, fork (or clone with git) [this repository](https://github.com/Bjarnos/RSS-bot). It's a modified copy of [this repository](https://github.com/Qolors/FeedCord), adapted by me to be fit for Koyeb.

The only thing you'll need to change is the `appsettings.json`. Here is an example configuration (note: JSON does not support comments, so remove these before using):
```json
{
  "Instances": [
    {
      "Id": "My First News Feed", 
      "YoutubeUrls": [
        "https://www.youtube.com/feeds/videos.xml?channel_id=UCX6OQ3DkcsbYNE6H8uQQuVA" // example, MrBeast
      ],
      "RssUrls": [
        "http://feeds.bbci.co.uk/news/world/rss.xml" // example, BBC
      ],
      "Forum": false, // IMPORTANT | if your webhook is in a forum channel set this to true
      "DiscordWebhookUrl": "https://discord.com/api/webhooks/ID/TOKEN", // IMPORTANT | your discord webhook url
      "RssCheckIntervalMinutes": 20,
      "EnableAutoRemove": false,
      "Color": 8411391,
      "DescriptionLimit": 250,
      "MarkdownFormat": false,
      "PersistenceOnShutdown": true,
      "PersistenceFolderPath": "/app/persistence" // IMPORTANT | path to your Koyeb volume
    }
  ],
  "ConcurrentRequests": 40
}
```

Next, go to [Koyeb](https://app.koyeb.com/) and open the [Volumes section](https://app.koyeb.com/). Create a volume and set its `Size` to 10 GB (better safe than sorry). The `Name` and `Region` can be anything; just pick a region close to your instance.

Then, create a new instance. In the settings, set `Builder` to `Dockerfile` (no need to change location or command). Under settings -> Volumes, add the volume you created, and set the `Mount path` to **exactly** the same path as `PersistenceFolderPath` in your `appsettings.json` (default is `/app/persistence`).

After saving and deploying, your bot should be running and monitoring your feeds!
If you encounter any issues, feel free to reply here or send me a DM.

Overview of all variables possible in `appsettings.json`:
```cs
Required:
- string Id
- string[] RssUrls
- string[] YoutubeUrls
- string DiscordWebhookUrl
- int RssCheckIntervalMinutes
- int DescriptionLimit
- bool Forum
- bool MarkdownFormat
- bool PersistenceOnShutdown
- string PersistenceFolderPath

Optional:
- string Username
- string AvatarUrl
- string AuthorIcon
- string AuthorName
- string AuthorUrl
- string FallbackImage
- string FooterImage
- int Color
- bool EnableAutoRemove
- List<PostFilters> PostFilters
- Dictionary<string, string[]> Pings
- int ConcurrentRequests
```
