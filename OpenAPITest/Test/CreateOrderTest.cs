using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class CreateOrderTest : BaseTest<CreateOrderCondition, CreateOrderResult>
    {
        protected override bool RequriedHttps { get { return true; } }
        protected override string Method { get { return "hotel.order.create"; } }

        string hotelId; string roomTypeId; int rpId; DateTime cin; DateTime cout; decimal totalPrice;
        EnumPaymentType paymentType; int numOfRooms;

        EnumGuestTypeCode guestType; EnumCurrencyCode currency;

        bool _isInited = false;

        public void SetParameters(string hotelId, string roomTypeId, int rpId, DateTime cin, DateTime cout,
            decimal totalPrice, EnumGuestTypeCode guestType, EnumCurrencyCode currency, EnumPaymentType paymentType, int numOfRooms)
        {
            this.hotelId = hotelId;
            this.roomTypeId = roomTypeId;
            this.rpId = rpId;
            this.cin = cin;
            this.cout = cout;
            this.totalPrice = totalPrice;
            this.guestType = guestType;
            this.currency = currency;

            this.paymentType = paymentType;
            this.numOfRooms = numOfRooms;

            _isInited = true;
        }

        protected override CreateOrderCondition GetRequestCondition()
        {

            if (!_isInited)
            {

                //SetParameters("10101129", "0001", 115250, DateTime.Now.Date.AddDays(6),
                //    DateTime.Now.Date.AddDays(7), 600, EnumGuestTypeCode.Chinese, EnumCurrencyCode.RMB, EnumPaymentType.Prepay, 1);

                SetParameters("10101129", "0006", 103794, DateTime.Now.Date.AddDays(1),
                    DateTime.Now.Date.AddDays(2), 800, EnumGuestTypeCode.Chinese, EnumCurrencyCode.RMB, EnumPaymentType.SelfPay, 1);

            }

            DateTime checkInDate = cin;
            DateTime checkOutDate = cout; 

            Random rnd = new Random();
            

            CreateOrderCondition condition = new CreateOrderCondition()
            {
                ArrivalDate = checkInDate,
                DepartureDate = checkOutDate,
                //HotelId = "30101183",
                //RoomTypeId = "1068",
                //RatePlanId = 101813,
                HotelId = hotelId,
                RoomTypeId = roomTypeId,
                RatePlanId = rpId,
                AffiliateConfirmationId = Guid.NewGuid().ToString(),
                //ConfirmationLanguage = EnumLocal.zh_CN,
                ConfirmationType = EnumConfirmationType.SMS_cn,
                CurrencyCode = currency,
                CustomerIPAddress = "127.0.0.1",
                CustomerType = guestType,
                EarliestArrivalTime = checkInDate.AddHours(14),
                LatestArrivalTime = checkInDate.AddHours(19),
                IsNeedInvoice = false,
                IsGuaranteeOrCharged = true,
                NumberOfCustomers = numOfRooms,
                NumberOfRooms = numOfRooms,
                PaymentType = paymentType,
                TotalPrice = totalPrice * numOfRooms,


                Contact = new Contact() { Name = "张飞" + rnd.Next(1000, 10000), 
                    Mobile = "186" + rnd.Next(100000000, 1000000000) },
                OrderRooms = new CreateOrderRoom[] { 
                    new CreateOrderRoom() { 
                        Customers = new CustomerForOrder[] { 
                            new CustomerForOrder() { 
                                Name = "李静"+ rnd.Next(100000,10000000),
                                Nationality = "中国"
                            },
                           
                        }
                    },
                    //new CreateOrderRoom() { 
                    //    Customers = new CustomerForOrder[] { 
                            
                    //        new CustomerForOrder() { 
                    //            Name = "张静"+ rnd.Next(100000,10000000), Nationality = "中国"
                    //        }
                    //    }
                    //}
                },
                ExtendInfo = new ExtendInfo() {
                 String1 = "abc"
                }

            };

            return condition;
        }

    }
}
