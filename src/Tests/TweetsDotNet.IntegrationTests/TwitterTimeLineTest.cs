namespace TweetsDotNet.IntegrationTests
{
    using System;
    using System.Linq;
    using Xunit;

    public class TwitterTimeLineTest
    {
        public TwitterTimeLineTest()
        {
            Target = new TwitterTimeLine();
        }

        private TwitterTimeLine Target { get; set; }

        [Fact]
        public void GetTweets()
        {
            var tweets = Target.GetTweets("topascz").ToArray();

            Assert.Equal(10, tweets.Length);

            foreach (var tweet in tweets)
            {
                AssertValidTweet(tweet);
            }
        }

        [Fact]
        public void GetTweetsWithCount()
        {
            const int count = 20;
            var tweets = Target.GetTweets("topascz", count).ToArray();

            Assert.Equal(count, tweets.Length);

            foreach (var tweet in tweets)
            {
                AssertValidTweet(tweet);
            }
        }

        [Fact]
        public void GetTweetsWrongScreenName()
        {
            Assert.Throws<ArgumentNullException>(() => {
                Target.GetTweets(null).ToArray();
            });
        }

        [Fact]
        public void GetTweetsCountOutOfRange1()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Target.GetTweets("topascz", 0).ToArray();
            });
        }

        [Fact]
        public void GetTweetsCountOutOfRange2()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Target.GetTweets("topascz", 201).ToArray();
            });
        }

        private void AssertValidTweet(Tweet tweet)
        {
            Assert.NotNull(tweet.Text);
            Assert.NotEqual(DateTime.MinValue, tweet.CreatedAt); 
            Assert.NotNull(tweet.Link);
            Assert.NotNull(tweet.Author);

            AssertValidAuthor(tweet.Author);
        }

        private void AssertValidAuthor(TwitterUser user)
        {
            Assert.NotNull(user.Name);
            Assert.NotNull(user.ScreenName);
            Assert.NotNull(user.Url);
            Assert.NotNull(user.Description);
            Assert.NotNull(user.Location);
            Assert.True(user.TweetsCount > 0);
            Assert.True(user.Followers > 0);
            Assert.True(user.Following > 0);
        }
    }
}
