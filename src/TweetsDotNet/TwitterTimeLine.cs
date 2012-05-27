namespace TweetsDotNet
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Xml.Linq;

    public class TwitterTimeLine : ITwitterTimeLine
    {
        private const string Url = "https://api.twitter.com/1/statuses/user_timeline.xml?screen_name={0}&count={1}&include_rts=1";
        private const string LinkUrl = "https://twitter.com/{0}/status/{1}";

        public System.Collections.Generic.IEnumerable<Tweet> GetTweets(string screenName, int count = 10)
        {
            if (String.IsNullOrEmpty(screenName))
            {
                throw new ArgumentNullException("screenName");
            }

            if (count < 1 || count > 200)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            var xml = GetXmlResponse(screenName, count);

            foreach (var statusXml in xml.Descendants("status"))
            {
                yield return ParseTweet(screenName, statusXml);
            }
        }

        private Tweet ParseTweet(string screenName, XElement statusXml)
        {
            var author = ParseAuthor(statusXml.Element("user"));
            var text = statusXml.Element("text").Value;
            var created = DateTime.ParseExact(statusXml.Element("created_at").Value,
                                               "ddd MMM dd HH:mm:ss zzz yyyy", 
                                               System.Globalization.CultureInfo.InvariantCulture);
            var id = statusXml.Element("id").Value;
            var link = String.Format(LinkUrl, screenName, id);

            return new Tweet(author, text, created, link); 
        }

        private TwitterUser ParseAuthor(XElement userXml)
        {
            var name = userXml.Element("name").Value;
            string screenName = userXml.Element("screen_name").Value;
            string description = userXml.Element("description").Value;
            string url = userXml.Element("url").Value;
            string location = userXml.Element("location").Value;
            int followers = Int32.Parse(userXml.Element("followers_count").Value);
            int following = Int32.Parse(userXml.Element("friends_count").Value);
            int twittersCount = Int32.Parse(userXml.Element("statuses_count").Value);

            return new TwitterUser(name, screenName, description, url, location, followers, following, twittersCount);
        }

        private XDocument GetXmlResponse(string screenName, int count)
        {
            var url = String.Format(Url, screenName, count);

            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();

            return XDocument.Load(stream);
        }
    }
}
