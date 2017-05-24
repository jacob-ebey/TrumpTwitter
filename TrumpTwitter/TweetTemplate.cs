using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Models;
using Tweetinvi.Models.DTO;
using Tweetinvi.Models.Entities;

namespace TrumpTwitter
{
    class TweetTemplate : ITweet
    {
        public long Id { get; set; }
        public string FullText { get; set; }
        public string Source { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Text { get; set; }

        public string Prefix { get; set; }

        public string Suffix { get; set; }

        public int[] DisplayTextRange { get; set; }
        
        public bool Truncated { get; set; }

        public long? InReplyToStatusId { get; set; }
        public string InReplyToStatusIdStr { get; set; }
        public long? InReplyToUserId { get; set; }
        public string InReplyToUserIdStr { get; set; }
        public string InReplyToScreenName { get; set; }

        [JsonIgnore]
        IUser ITweet.CreatedBy { get; }
        [JsonProperty]
        public dynamic CreatedBy { get; set; }

        [JsonIgnore]
        ITweetIdentifier ITweet.CurrentUserRetweetIdentifier { get; }
        [JsonProperty]
        public dynamic CurrentUserRetweetIdentifier { get; set; }

        public int[] ContributorsIds { get; set; }

        public IEnumerable<long> Contributors { get; set; }

        public int RetweetCount { get; set; }

        [JsonIgnore]
        ITweetEntities ITweet.Entities { get; }
        [JsonProperty]
        public dynamic Entities { get; set; }

        public bool Favorited { get; set; }

        public int FavoriteCount { get; set; }

        public bool Retweeted { get; set; }

        public bool PossiblySensitive { get; set; }

        public Language Language { get; set; }

        [JsonIgnore]
        IPlace ITweet.Place { get; }
        public dynamic Place { get; set; }

        public Dictionary<string, object> Scopes { get; set; }

        public string FilterLevel { get; set; }

        public bool WithheldCopyright { get; set; }

        public IEnumerable<string> WithheldInCountries { get; set; }

        public string WithheldScope { get; set; }

        [JsonIgnore]
        ITweetDTO ITweet.TweetDTO { get; set; }
        public dynamic TweetDTO { get; set; }

        public int PublishedTweetLength { get; set; }

        public DateTime TweetLocalCreationDate { get; set; }

        [JsonIgnore]
        List<IHashtagEntity> ITweet.Hashtags { get; }
        public List<dynamic> Hashtags { get; set; }

        [JsonIgnore]
        List<IUrlEntity> ITweet.Urls { get; }
        [JsonProperty]
        public List<dynamic> Urls { get; set; }

        [JsonIgnore]
        public List<IMediaEntity> Media { get; set; }

        [JsonIgnore]
        List<IUserMentionEntity> ITweet.UserMentions { get; }
        [JsonProperty]
        public List<dynamic> UserMentions { get; set; }

        [JsonIgnore]
        List<ITweet> ITweet.Retweets { get; set; }
        [JsonProperty]
        public List<dynamic> Retweets { get; set; }

        public bool IsRetweet { get; set; }

        [JsonIgnore]
        ITweet ITweet.RetweetedTweet { get; }
        [JsonProperty]
        public dynamic RetweetedTweet { get; set; }

        public long? QuotedStatusId { get; set; }

        public string QuotedStatusIdStr { get; set; }

        [JsonIgnore]
        ITweet ITweet.QuotedTweet { get; }
        [JsonProperty]
        public dynamic QuotedTweet { get; set; }

        public bool IsTweetPublished { get; set; }

        public bool IsTweetDestroyed { get; set; }

        public string Url { get; set; }

        public string IdStr { get; set; }

        [JsonIgnore]
        IExtendedTweet ITweet.ExtendedTweet { get; set; }
        [JsonProperty]
        public dynamic ExtendedTweet { get; set; }
        
        [JsonIgnore]
        ICoordinates ITweet.Coordinates { get; set; }
        [JsonProperty]
        public dynamic Coordinates { get; set; }

        public int CalculateLength(bool willBePublishedWithMedia)
        {
            throw new NotImplementedException();
        }

        public bool Destroy()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DestroyAsync()
        {
            throw new NotImplementedException();
        }

        public bool Equals(ITweet other)
        {
            throw new NotImplementedException();
        }

        public void Favorite()
        {
            throw new NotImplementedException();
        }

        public Task FavoriteAsync()
        {
            throw new NotImplementedException();
        }

        public IOEmbedTweet GenerateOEmbedTweet()
        {
            throw new NotImplementedException();
        }

        public Task<IOEmbedTweet> GenerateOEmbedTweetAsync()
        {
            throw new NotImplementedException();
        }

        public List<ITweet> GetRetweets()
        {
            throw new NotImplementedException();
        }

        public Task<List<ITweet>> GetRetweetsAsync()
        {
            throw new NotImplementedException();
        }

        public ITweet PublishRetweet()
        {
            throw new NotImplementedException();
        }

        public Task<ITweet> PublishRetweetAsync()
        {
            throw new NotImplementedException();
        }

        public void UnFavorite()
        {
            throw new NotImplementedException();
        }

        public Task UnFavoriteAsync()
        {
            throw new NotImplementedException();
        }

        public bool UnRetweet()
        {
            throw new NotImplementedException();
        }
    }
}
