using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenAPITest.Test;
using System.IO;
using OpenAPITest.Gtest;
using OpenAPITest.util;

/*
 * NOTEICE:
 * 
 * 强烈建议使用json格式。
 * 自动生成的Model，在使用xml格式的时候，有效属性需要指定Attitude来匹配响应的xml，如：
 *      [XmlArray("RatePlans")]
        [XmlArrayItem("RatePlan")]
        public ListRatePlan[] RatePlans {get;set;} 
 * 
 * 
 * 
 */

namespace OpenAPITest
{
    class Program
    {
        static void Main(string[] args)
        {

            //var str = HttpRequest.Get("http://pmgs.kongfz.com/detail/129_418951/");
            //Console.WriteLine(str);
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadKey();

            System.Net.ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);

            //string str = File.ReadAllText("c:\\t.txt").Trim();
            //string sig = Tools.MD5(1372564951 + Tools.MD5(str + "70d4f84b99209a631a3de51978d6a4ee") + "0245e52b8e2a3518b1a01b7694752528");
            //Console.WriteLine(sig);
            //Console.WriteLine(str);
            //Console.WriteLine(Uri.EscapeDataString(str));
            
            //T2();
            //GOrderDetail
            //GOrderCreateTest
            //GHotelListTest
            //var test = new GHotelDetailTest();
            //var test = new GHotelListTest();
            //GHotelOrderListTest

            //var test = new GRoomAvailableTest();
            //var test = new GHotelListTest();

            
            //var test = new ValidateTest();
            //var test = new RatePlanTest();

            var test = new CreateOrderTest();
            //var test = new InstantOrderTest();
            //var test = new OrderDetailTest();
            // var test = new UpdateOrderTest();

            //var test = new RateTest();
            //var test = new InventoryTest();
            //var test = new IncrRateTest();

            //var test = new HotelListTest();
            //var test = new HotelDetailTest();
            //var test = new InvValidateTest();
            //var test = new IncrStateTest();

            //var test = new ExchangeRateTest();

            //test.SetParameters("52003050", "0005", 2621, DateTime.Now.Date.AddDays(5), DateTime.Now.Date.AddDays(6), 508, EnumGuestTypeCode.All, EnumCurrencyCode.RMB, EnumPaymentType.SelfPay,1);
            var r = test.Test(true);

            //long lastId = 281475956371262; //281475955781000;
            //while (true)
            //{
            //    var test = new IncrOrderTest();
            //    test.SetLastId(lastId + 1);
            //    var r = test.Test(false);
            //    if (r.Code == "0")
            //    {
            //        if (r.Result != null && r.Result.Orders != null && r.Result.Orders.Length > 0)
            //        {
            //            foreach (var o in r.Result.Orders)
            //            {
            //                lastId = o.LastId;
            //                Console.WriteLine(lastId);
                            
            //            }
            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //    Console.WriteLine();
            //}


            //var res = (new HotelDetailTest()).Test(true);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void T()
        {
            string[] hotelIds = File.ReadAllLines("c:\\hotelId.txt");
            foreach (string id in hotelIds)
            {
                if (string.IsNullOrEmpty(id))
                {
                    continue;
                }

                bool showed = false;
                var r1 = new HotelDetailTest();
                r1.Condition = new HotelDetailCondition()
                {
                    ArrivalDate = DateTime.Now.Date.AddDays(4),
                    DepartureDate = DateTime.Now.Date.AddDays(6),
                    HotelIds = id,
                };
                BaseResponse<HotelList> detail = r1.Test();
                if (detail.Code == "0" && detail.Result != null)
                {
                    var hs = detail.Result.Hotels;
                    if (hs != null)
                        foreach (var h in hs)
                        {
                            if (h.Rooms != null)
                            {
                                var r2 = new InventoryTest();
                                r2.Condition = new InventoryCondition()
                                {
                                    StartDate = DateTime.Now.Date.AddDays(4),
                                    EndDate = DateTime.Now.Date.AddDays(6),
                                    HotelIds = id
                                };

                                var res2 = r2.Test();
                                bool ok = true;
                                if (res2.Result.Inventories != null)
                                {
                                    foreach (var inv in res2.Result.Inventories)
                                    {
                                        ok = ok && inv.Status;
                                    }
                                    //Console.WriteLine("\t\tinv: " + ok);
                                }

                                var r3 = new RateTest();
                                r3.Condition = new RateCondition()
                                {
                                    StartDate = DateTime.Now.Date.AddDays(4),
                                    EndDate = DateTime.Now.Date.AddDays(6),
                                    HotelIds = id,
                                    PaymentType = EnumPaymentType.Prepay
                                };
                                var res3 = r3.Test();
                                if (res3.Result.Rates != null)
                                {
                                    //Console.WriteLine("\t\trate: " + res3.Result.Rates.Length);
                                }


                                foreach (var r in h.Rooms)
                                {
                                    if (r.RatePlans != null)
                                        foreach (var rp in r.RatePlans)
                                        {
                                            if (rp.PaymentType == EnumPaymentType.Prepay)
                                            {
                                                int invCount = 0;
                                                if (res2.Result.Inventories != null)
                                                {
                                                    foreach (var inv in res2.Result.Inventories)
                                                    {
                                                        if (inv.RoomTypeId == r.RoomId)
                                                        {
                                                            invCount = inv.Status ? (inv.OverBooking == 0 ? 999 : inv.Amount) : -1;
                                                        }
                                                    }
                                                }

                                                decimal price = 0M;
                                                if (res3.Result.Rates != null)
                                                {
                                                    foreach (var rate in res3.Result.Rates)
                                                    {
                                                        if (rate.Status && rate.StartDate <= r2.Condition.StartDate && rate.EndDate >= r2.Condition.EndDate)
                                                        {
                                                            price = rate.MemberCost;
                                                        }
                                                    }

                                                }

                                                Console.WriteLine(string.Format("{0} {1} {2} {3} {4}", h.HotelId, r.RoomId, rp.RatePlanId, invCount, price));


                                                showed = true;
                                            }
                                        }
                                }
                            }
                        }
                }
                if (!showed)
                    Console.WriteLine("===> " + id);
            }
        }

        static void T2()
        {
            //T();
            int n = 9;
            while (n < 10)
            {
                var res = (new HotelDetailTest()).Test(true);
                //Console.WriteLine(res.Result.Count);

                //(new InventoryTest()).Test(true);
                //(new RateTest()).Test(true);
                //(new HotelDetailTest()).Test(true);

                System.Threading.Thread.Sleep(1000);
                n++;
            }
        }

        //static void T()
        //{
        //    List<Testable> list = new List<Testable>() {

        //        new HotelListTest(),

        //        new  HotelDetailTest(),

        //        new CreateOrderTest(),

        //        new RatePlanTest(),
        //        new InventoryTest(),
        //        new RateTest(),

        //         new ValidateTest(),

        //        new OrderListTest(),
        //        new UpdateOrderTest(),
        //        new CancelOrderTest(),

        //        new OrderDetailTest(),
        //        new RecentOrderTest(),
        //        new RelatedOrderTest(),



        //        new IncrLastIdTest(),
        //        new IncrOrderTest(),
        //        new IncrInvTest(),
        //        new IncrRateTest(),
        //        new InstantOrderTest(),
        //    };

        //    foreach (var req in list)
        //    {
        //        req.Test();
        //    }
        //}
    }
}
