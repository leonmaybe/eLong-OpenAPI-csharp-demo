using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenAPITest.Test;
using System.Text.RegularExpressions;
using OpenAPITest.util;

namespace OpenAPITest
{
    public abstract class BaseTest<T, T2>  // : Testable
    {
        private string _format = "xml";
        public static string URL = System.Configuration.ConfigurationManager.AppSettings["BASE_URL"];
        public static string URL_HTTPS = System.Configuration.ConfigurationManager.AppSettings["BASE_URL_HTTPS"];

        public static string APIUSER = System.Configuration.ConfigurationManager.AppSettings["APIUSER"];
        public static string APPKEY = System.Configuration.ConfigurationManager.AppSettings["APPKEY"];
        public static string SECRETKEY = System.Configuration.ConfigurationManager.AppSettings["SECRETKEY"];

        


        protected abstract string Method { get; }
        protected abstract bool RequriedHttps { get; }
        protected abstract T GetRequestCondition();
        protected virtual bool IsGHotel { get; set; }

        protected virtual void ActionAfterTest(T2 obj) { }

        public BaseResponse<T2> Test()
        {
            return Test(false);
        }

        public BaseResponse<T2> Test(bool Verbose)
        {
            var condition = GetRequestCondition();
            string str = string.Empty;

            if (IsGHotel)
            {
                str = SearilizeObject.Searilize(_format, typeof(T), condition, typeof(T));
            }
            else
            {
                var request = new BaseRequest<T>()
                {
                    Local = EnumLocal.en_US,
                    Version = 1.07,
                    Request = condition
                };
                str = SearilizeObject.Searilize(_format, typeof(BaseRequest<T>), request, typeof(T));
            }
            
            

            //str = "{\"Local\":\"zh_CN\",\"Version\":1.01,\"Request\":{\"AffiliateConfirmationId\":\"362800163196268\",\"HotelId\":\"52301048\",\"RoomTypeId\":\"0014\",\"RatePlanId\":141529,\"ArrivalDate\":\"2013-06-21T00:00:00\",\"DepartureDate\":\"2013-06-22T00:00:00\",\"CustomerType\":\"All\",\"PaymentType\":\"Prepay\",\"NumberOfRooms\":1,\"NumberOfCustomers\":1,\"EarliestArrivalTime\":\"2013-06-21T14:00:00\",\"LatestArrivalTime\":\"2013-06-21T23:59:59\",\"CurrencyCode\":\"RMB\",\"TotalPrice\":914.00,\"CustomerIPAddress\":\"127.0.0.1\",\"IsGuaranteeOrCharged\":true,\"ConfirmationType\":\"SMS_cn\",\"ConfirmationLanguage\":\"zh_CN\",\"NoteToHotel\":\"要双床房\",\"IsNeedInvoice\":false,\"Contact\":{\"Name\":\"徐晗笑\",\"Mobile\":\"13916629698\",\"Gender\":\"Female\"},\"NightlyRates\":[{\"Member\":1219.00000,\"Cost\":914.0,\"Status\":false,\"Date\":\"2013-06-21T00:00:00\"}],\"OrderRooms\":[{\"Customers\":[{\"Name\":\"徐晗笑\",\"Gender\":\"Female\",\"Nationality\":\"中国\"}]}]}}";
            //str = "{\"Local\":\"zh_CN\",\"Version\":1.01,\"Request\":{\"AffiliateConfirmationId\":\"365493248124422\",\"HotelId\":\"52507006\",\"RoomTypeId\":\"0001\",\"RatePlanId\":221233,\"ArrivalDate\":\"2013-06-13T00:00:00\",\"DepartureDate\":\"2013-06-15T00:00:00\",\"CustomerType\":\"All\",\"PaymentType\":\"Prepay\",\"NumberOfRooms\":1,\"NumberOfCustomers\":1,\"EarliestArrivalTime\":\"2013-06-13T14:00:00\",\"LatestArrivalTime\":\"2013-06-13T23:59:59\",\"CurrencyCode\":\"RMB\",\"TotalPrice\":736.00,\"CustomerIPAddress\":\"127.0.0.1\",\"IsGuaranteeOrCharged\":true,\"ConfirmationType\":\"NoNeed\",\"ConfirmationLanguage\":\"zh_CN\",\"IsNeedInvoice\":false,\"Contact\":{\"Name\":\"张立贤\",\"Mobile\":\"15025054433\",\"Gender\":\"Female\"},\"OrderRooms\":[{\"Customers\":[{\"Name\":\"张立贤\",\"Gender\":\"Female\",\"Nationality\":\"中国\"}]}]}}";
            //str = "{\"CreatorIP\":\"10.10.124.155\",\"ContactPersonName\":\"王|成\",\"Email\":\"13439876721@qq.com\",\"MobileTelephone\":\"13439876721\",\"Sex\":\"Male\",\"ArriveHotelTime\":\"2013-08-28T08:00:00\",\"AverageBaseRate\":137.4,\"AverageRate\":137.4,\"CheckInDate\":\"2013-08-28\",\"CheckOutDate\":\"2013-08-29\",\"CurrencyCode\":\"CNY\",\"HotelID\":\"414797\",\"HotelName\":\"嘉乐悦活精品酒店\",\"InterHotelRoomTypes\":[{\"AdultNum\":1,\"BedTypeID\":\"200194958\",\"BedTypeName\":\"1单人床\",\"ChildAge\":\"5\",\"ChildNum\":0,\"GuestName\":\"wang|cheng\",\"RoomCode\":\"201117826\",\"RoomTypeID\":\"200194958\",\"RoomTypeName\":\"标准单人房\"}],\"MaxNightlyRate\":137.4,\"NightlyRateTotal\":138.39,\"RoomNum\":1,\"SurchargeTotal\":20.61,\"Total\":159.0,\"extraPersonFees\":0.0,\"InvoiceFee\":0.0,\"InvoiceTitle\":\"卡莱特集团\",\"CertificateNO\":\"110227197603029976\",\"CertificateType\":\"IdentityCard\",\"IsInternationalCard\":false,\"AgencyOrderID\":\"ludj0000002310\",\"IsGurantedOrCharged\":1}";
            
            if (Verbose)
            {
                Console.WriteLine(Method);
                Console.WriteLine();

                Console.WriteLine(str);
                Console.WriteLine();
            }

            DateTime now = DateTime.Now;
            long timestamp = Tools.ConvertDateTimeInt(now);
            string sig = Tools.MD5(timestamp + Tools.MD5(str + APPKEY) + SECRETKEY);
            

            StringBuilder sb = new StringBuilder();
            sb.Append("format=").Append(_format).Append("&");
            sb.Append("method=").Append(Method).Append("&");
            sb.Append("signature=").Append(sig).Append("&");
            sb.Append("user=").Append(APIUSER).Append("&");
            sb.Append("timestamp=").Append(timestamp).Append("&");


            str = Uri.EscapeDataString(str);

            sb.Append("data=").Append(str);

            if (Verbose)
            {
                Console.WriteLine(now);
                Console.WriteLine();
            }

            string url = string.Format(RequriedHttps ? URL_HTTPS : URL, sb.ToString());

            if (Verbose)
            {
                Console.WriteLine(url);
                Console.WriteLine();
            }

            string res = HttpRequest.Get(url);
            System.IO.File.WriteAllText(@"c:\api-res.txt", res);
            if (res == null)
            {
                Console.WriteLine("ERROR: Response NULL");
                return null;
            }
            if (Verbose)
            {
                Console.WriteLine(res);

                //System.IO.File.WriteAllText("c:\\res.xml", res);
            }

            if (_format == "xml")
            {
                res = res.Replace("\n", "");
                res = res.Replace("\r", "");
                //res = res.Replace("?><Result>", "?><ApiResult>");
                //res = res.Substring(0, res.Length - "/Result>".Length) + "/ApiResult>";
                res = Regex.Replace(res, "<\\w+/>", "");
                res = Regex.Replace(res, "<([^>]+)></\\1>", "");
            }

            BaseResponse<T2> result = null;
            if (typeof(T2) != typeof(object))
            {
                try
                {

                    result = SearilizeObject.Deserialize<BaseResponse<T2>>(_format, res);
                    if (Verbose)
                    {
                        if (result != null)
                            Console.WriteLine(result.Code);
                    }

                    ActionAfterTest(result.Data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine( ex.Message);                    
                }
            }
            
            return result;

                
        }

        
    
    }
}
