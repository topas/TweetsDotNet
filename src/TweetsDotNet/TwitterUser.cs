namespace TweetsDotNet
{
    public class TwitterUser
    {
        public TwitterUser(string name, 
                           string screenName, 
                           string description, 
                           string url, 
                           string location, 
                           int followers,
                           int following, 
                           int tweetsCount)
        {
            Name = name;
            ScreenName = screenName;
            Description = description;
            Url = url;
            Location = location;
            Followers = followers;
            Following = following;
            TweetsCount = tweetsCount;
        }

        public string Name { get; private set; }
        public string ScreenName { get; private set; }
        public string Description { get; private set; }
        public string Url { get; private set; }
        public string Location { get; private set; }

        public int Followers { get; private set; }
        public int Following { get; private set; }
        public int TweetsCount { get; private set; }
    }
}
