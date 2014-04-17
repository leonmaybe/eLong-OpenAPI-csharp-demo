using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml;

namespace OpenAPITest
{
    public class HttpRequest
    {
        public static string Get(string url)
        {
            return Send("GET", url, "");
        }

        public static string Post(string url,string postData)
        {
            return Send("POST", url, postData);
        }
        public static string Send(string verb, string url, string postData)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            //System.Net.WebProxy proxy = new WebProxy("10.10.101.9", 8080);
            //proxy.Credentials = new NetworkCredential("lx09140019", "118200");
            //req.Proxy = proxy;
            

            req.Timeout = 60 * 1000;
            //req.Headers.Add("Accept-Encoding", "gzip,deflate");
            req.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.110 Safari/537.36";
            
            req.Method = verb;

            try
            {
                if (verb == "POST")
                {
                    byte[] data = Encoding.UTF8.GetBytes(postData);

                    req.ContentType = "application/text; charset=utf-8";
                    req.ContentLength = data.Length;
                    
                    Stream requestStream = req.GetRequestStream();
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Close();
                }


                using (var res = req.GetResponse())
                {
                    using (var stream = res.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                        string response = sr.ReadToEnd();

                        sr.Close();

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HTTP Exception: "+ex.Message);
            }
            return null;
        }
    }
}
