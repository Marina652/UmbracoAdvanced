using System.Text.Json.Serialization;

namespace UmbracoProject1.umbraco.models.DTOs;

public class GithubUserDTO
{
    [JsonPropertyName("githubUsername")]
    public string UserName { get; set; }

    [JsonPropertyName("githubPreferredLanguage")]
    public string PreferredProgrammingLanguage { get; set; }
}
