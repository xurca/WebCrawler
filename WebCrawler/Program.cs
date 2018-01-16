using System;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var crawler = new Crawler();
            var content1 = crawler.CrawlPage();
            var content2 = crawler.Crawl().Result;

            Logging.WriteToFile(content1);
            Logging.WriteToFile(content2);
        }
    }
}
