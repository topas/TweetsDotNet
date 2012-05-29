namespace TweetsDotNet.UnitTests
{
    using System;
    using Xunit;

    public class TweetExtensionsTest
    {
        [Fact]
        public void TweetToHtmlFormatHttpLink()
        {
            var text = "Testing link http://www.twitter.com";
            var tweet = new Tweet(new TwitterUser(null, null, null, null, null, 0, 0, 0), text, DateTime.MinValue, String.Empty);

            Assert.Equal("Testing link <a href=\"http://www.twitter.com\">http://www.twitter.com</a>", tweet.TextToHtmlString().ToString());
        }

        [Fact]
        public void TweetToHtmlFormatHttpsLink()
        {
            var text = "Testing link https://www.twitter.com";
            var tweet = new Tweet(new TwitterUser(null, null, null, null, null, 0, 0, 0), text, DateTime.MinValue, String.Empty);

            Assert.Equal("Testing link <a href=\"https://www.twitter.com\">https://www.twitter.com</a>", tweet.TextToHtmlString().ToString());
        }

        [Fact]
        public void TweetToHtmlFormatNotLink()
        {
            var text = "Testing link www.twitter.com";
            var tweet = new Tweet(new TwitterUser(null, null, null, null, null, 0, 0, 0), text, DateTime.MinValue, String.Empty);

            Assert.Equal("Testing link www.twitter.com", tweet.TextToHtmlString().ToString());
        }

        [Fact]
        public void TweetToHtmlFormatUsernames()
        {
            var text = "RT @topascz: Test tweet";
            var tweet = new Tweet(new TwitterUser(null, null, null, null, null, 0, 0, 0), text, DateTime.MinValue, String.Empty);

            Assert.Equal("RT <a href=\"https://www.twitter.com/topascz\">@topascz</a>: Test tweet", tweet.TextToHtmlString().ToString());
        }

        [Fact]
        public void TweetToHtmlFormatNotUsernames()
        {
            var text = "Some email test@test.com @123";
            var tweet = new Tweet(new TwitterUser(null, null, null, null, null, 0, 0, 0), text, DateTime.MinValue, String.Empty);

            Assert.Equal("Some email test@test.com @123", tweet.TextToHtmlString().ToString());
        }

        [Fact]
        public void TweetToHtmlFormatHashtags()
        {
            var text = "Next #test #like";
            var tweet = new Tweet(new TwitterUser(null, null, null, null, null, 0, 0, 0), text, DateTime.MinValue, String.Empty);

            Assert.Equal("Next <a href=\"https://www.twitter.com/search/#test\">#test</a> <a href=\"https://www.twitter.com/search/#like\">#like</a>", tweet.TextToHtmlString().ToString());
        }

        [Fact]
        public void TweetToHtmlFormatNotHashtags()
        {
            var text = "Next test#test";
            var tweet = new Tweet(new TwitterUser(null, null, null, null, null, 0, 0, 0), text, DateTime.MinValue, String.Empty);

            Assert.Equal("Next test#test", tweet.TextToHtmlString().ToString());
        }
    }
}
