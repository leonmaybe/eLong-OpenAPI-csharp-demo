using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.util
{
    public class CreditCardEncrypt
    {
        public static string APPKEY = System.Configuration.ConfigurationManager.AppSettings["APPKEY"];

        public static string Encrypt(string card)
        {

            string key = APPKEY.Substring(APPKEY.Length - 8, 8);

            long now = Tools.ConvertDateTimeInt(DateTime.Now);

            return Tools.DesEncrypt( now + "#" + card, key);


        }
    }
}
