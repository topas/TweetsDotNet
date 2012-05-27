namespace TweetsDotNet
{
    using System;

    public class Tweet
    {
        public Tweet(TwitterUser author, string text, DateTime createdAt, string link)
        {
            Author = author;
            Text = text;
            CreatedAt = createdAt;
            Link = link;
        }

        public TwitterUser Author { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Link { get; private set; }
    }
}
