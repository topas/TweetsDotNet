namespace TweetsDotNet
{
    using System;
    using System.Text.RegularExpressions;
    using System.Web;

    public static class TweetExtensions
    {
        public static HtmlString TextToHtmlString(this Tweet tweet)
        {
            var text = tweet.Text;

            text = FormatLinks(text);
            text = FormatUsernames(text);
            text = FormatHashtags(text);

            return new HtmlString(text);
        }

        private static string FormatLinks(string text)
        {
            return Regex.Replace(text, 
                                 @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])",
                                 delegate(Match match)
                                 {

                                    return string.Format("<a href=\"{0}\">{0}</a>", match.ToString());

                                 });
        }

        private static string FormatUsernames(string text)
        {
            return Regex.Replace(text,
                                 @"(?<=^|(?<=[^a-zA-Z0-9-_\.]))@([A-Za-z]+[A-Za-z0-9]+)",
                                 delegate(Match match)
                                 {

                                     return string.Format("<a href=\"https://www.twitter.com/{0}\">{1}</a>", 
                                                            match.ToString().TrimStart('@'), 
                                                            match.ToString());

                                 });
        }

        private static string FormatHashtags(string text)
        {
            return Regex.Replace(text,
                                 @"(?<=^|(?<=[^a-zA-Z0-9-_\.]))#([A-Za-z]+[A-Za-z0-9]+)",
                                 delegate(Match match)
                                 {

                                     return string.Format("<a href=\"https://www.twitter.com/search/{0}\">{0}</a>",
                                                            match.ToString());

                                 });
        }
    }
}
