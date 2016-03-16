using System.IO;
using System.Net;
using System.Text;

namespace Peon
{
    public static class JsonWebServiceObsolete
    {
        public static string GetString(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
    }
}
