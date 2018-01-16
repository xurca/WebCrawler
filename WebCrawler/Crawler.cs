using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebCrawler
{
    public class Crawler
    {
        public string url1;
        public string url2;

        public Crawler()
        {
            url1 = ConfigurationManager.AppSettings["url1"];
            url2 = ConfigurationManager.AppSettings["url2"];
        }

        public async Task<string> Crawl()
        {
            using (HttpClient client = new HttpClient() { Timeout = TimeSpan.FromMinutes(1) })
            {
                string html = await client.GetStringAsync(url2);
                return html;
            }
        }

        public string CrawlPage()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url1);
            request.UserAgent = "A Web Crawler";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string htmlText = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            return htmlText;
        }
    }
}
