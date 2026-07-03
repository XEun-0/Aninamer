using Newtonsoft.Json;
using System.Collections.Generic;

public class AniDbResponse
{
    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

    [JsonProperty("data")]
    public AniDbData Data { get; set; }
}

public class AniDbData
{
    [JsonProperty("anime")]
    public AnimeInfo Anime { get; set; }

    [JsonProperty("episodes")]
    public List<EpisodeEntry> Episodes { get; set; }
}

public class AnimeInfo
{
    [JsonProperty("aid")]
    public int Aid { get; set; }

    [JsonProperty("title")]
    public string AnimeName { get; set; } = string.Empty;

    [JsonProperty("shortTitle")]
    public string AnimeNameShort { get; set; } = string.Empty;

    [JsonProperty("episodeCount")]
    public int EpisodeCount { get; set; }

    [JsonProperty("animeAirDate")]
    public string AirDateYear { get; set; } = string.Empty;
}

public class EpisodeEntry
{
    [JsonProperty("eid")]
    public int Eid { get; set; }

    [JsonProperty("episodeNumber")]
    public string EpisodeNumber { get; set; } = string.Empty;

    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;
}

public class ServerAliveResponse
{
    [JsonProperty("success")]
    public bool Success { get; set; }
}