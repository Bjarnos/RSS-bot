﻿using System.ComponentModel.DataAnnotations;

namespace FeedCord.Common
{
    public class Config
    {
        [Required(ErrorMessage = "The 'Id' Property is required. \"Id\": \"MyFeedName\"")]
        public string Id { get; set; }

        [Required(ErrorMessage = "RssUrls Property is required (use an empty array if none) - \"RssUrls\": [\"\"]")]
        public string[] RssUrls { get; set; }

        [Required(ErrorMessage = "YoutubeUrls Property is required (use an empty array if none) - \"YoutubeUrls\": [\"\"]")]
        public string[] YoutubeUrls { get; set; }

        [Required(ErrorMessage = "DiscordWebhookUrl Property is required.")]
        public string DiscordWebhookUrl { get; set; }

        [Required(ErrorMessage = "RssCheckIntervalMinutes Property is required.")]
        public int RssCheckIntervalMinutes { get; set; }
        public string? Username { get; set; }
        public string? AvatarUrl { get; set; }
        public string? AuthorIcon { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorUrl { get; set; }
        public string? FallbackImage { get; set; }
        public string? FooterImage { get; set; }
        public int Color { get; set; }
        public bool EnableAutoRemove { get; set; }

        [Required(ErrorMessage = "Description Limit Property is required.")]
        public int DescriptionLimit { get; set; }
        [Required(ErrorMessage = "Forum Property is required (True for Forum Channels, False for Text Channels)")]
        public bool Forum { get; set; }
        [Required(ErrorMessage = "Markdown Property is required (True for Markdown Posts, False for Embed Posts)")]
        public bool MarkdownFormat { get; set; }
        [Required(ErrorMessage = "PersistenceOnShutdown Property is required (True for saving last scan date, False for new instance data on startup)")]
        public bool PersistenceOnShutdown { get; set; }
        [Required(ErrorMessage = "PersistenceFolderPath Property is required (set the path to a Koyeb Volume path)")]
        public string PersistenceFolderPath { get; set; }
        public List<PostFilters>? PostFilters { get; set; }
        public Dictionary<string, string[]>? Pings { get; set; }
        public int ConcurrentRequests { get; set; } = 5;
    }
}
