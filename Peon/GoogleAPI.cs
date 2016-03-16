using System;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Text;

namespace Peon
{
    public interface IGoogleAPIRequest
    {
        string URL { get; }
    }

    public class GoogleAPI
    {
        public const string serverKey = "AIzaSyAvpiuJ7xVf7Ti1ekqEovpahadvQhkXI9s";

        public static T Get<T>(IGoogleAPIRequest request)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(request.URL);
            WebResponse response = webRequest.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }
    }
}
