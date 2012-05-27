namespace TweetsDotNet
{
    using System.Collections.Generic;

    public interface ITwitterTimeLine
    {
        IEnumerable<Tweet> GetTweets(string screenName, int count = 10);
    }
}
