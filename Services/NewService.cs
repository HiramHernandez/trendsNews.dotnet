using TrendsNews.Models;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using TrendsNews.Utils;

namespace TrendsNews.Services
{
    public class NewService
    {

        public List<New> GetNews()
        {
            List<New> news = new List<New>();

            var newsXML = new WebClient().DownloadString(Constants.UrlMexicoNews);
            var myXml = XDocument.Parse(newsXML);

            foreach (var newElement in myXml.Descendants("item"))
            {
                string title = newElement.Element("title").Value;
                string link = newElement.Element("link").Value;
                string pubDate = newElement.Element("pubDate").Value;
                string descriptionHtml = newElement.Element("description").Value;
                string description = Regex.Replace(descriptionHtml, "<.*?>", string.Empty);

                news.Add(
                    new New(){ Title = title, Description = description, Link = link, PubDate = pubDate}
                );

            }
            return news;
        }
    }
}