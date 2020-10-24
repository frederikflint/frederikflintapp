using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace RedditShowerthoughts
{
    public class RedditPostResponse
    {
      [JsonPropertyName("data")]
      public RedditPostResponseData Data { get; set; }
    }

    public class RedditPostResponseData
    {
      [JsonPropertyName("children")]
      public IEnumerable<RedditPostData> Children { get; set; }

    }

    public class RedditPostData
    {
      [JsonPropertyName("data")]
      public RedditPost Data { get; set; }
    }

    public class RedditPost
    {
      [JsonPropertyName("title")]
      public string Title { get; set; }
    }
}
