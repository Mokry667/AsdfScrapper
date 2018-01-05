using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace WebRequestTest
{
    public class MailApi
    {
        private string url;
        private int timeout;

        public MailApi()
        {
            url = "https://asdf.pl/api/addresses/";
            timeout = 0;
        }

        public Message[] GetMessages(string username)
        {
            string combinedUrl = CombineUrl(username);
            string downloadedData = ApiCall(combinedUrl);
            return DeserializeJson(downloadedData);
        }

        private string CombineUrl(string username)
        {
            StringBuilder sBuilder =
                new StringBuilder(url + username + "@asdf.pl/messages");
            return sBuilder.ToString();
        }


        private string ApiCall(string url)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;

            // error 503 bad gateway not handled
            return webClient.DownloadString(url);
        }

        private Message[] DeserializeJson(string json)
        {
            return JsonConvert.DeserializeObject<Message[]>(json);
        }

        private int CountMessages(string url)
        {
            var json = new WebClient().DownloadString(url);
            Message[] messages = JsonConvert.DeserializeObject<Message[]>(json);
            return messages.Length;
        }

        public void Timeout()
        {
            Thread.Sleep(timeout * 1000);
        }

        public void SetTimeout(int seconds)
        {
            timeout = seconds;
        }
    }
}
