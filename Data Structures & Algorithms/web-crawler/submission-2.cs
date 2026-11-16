/**
 * // This is the HtmlParser's API interface.
 * // You should not implement it, or speculate about its implementation
 * interface HtmlParser {
 *     public IList<string> GetUrls(string url) {}
 * }
 */
using System.Runtime;

public class Solution {
    public IList<string> Crawl(string startUrl, HtmlParser htmlParser) {
        var startUrlHost = startUrl.Split('/')[2];

        var queue = new Queue<string>();
        queue.Enqueue(startUrl);
        var set = new HashSet<string>();
        set.Add(startUrl);
        var result = new List<string>() { startUrl };

        while (queue.Count > 0) {
            var queueLength = queue.Count;
            for (var i = 0; i < queueLength; i++) {
                var qUrl = queue.Dequeue();
                var urls = htmlParser.GetUrls(qUrl);
                foreach (var url in urls) {
                    var host = url.Split('/')[2];
                    var isHostValid = host == startUrlHost;

                    if (!set.Contains(url) && isHostValid) {
                        queue.Enqueue(url);
                        set.Add(url);
                        result.Add(url);
                    }
                }
            }
        }

        return result;
    }
}
