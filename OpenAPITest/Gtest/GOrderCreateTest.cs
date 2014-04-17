using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenAPITest.GModel;
using OpenAPITest.util;


namespace OpenAPITest.Gtest
{
    public class GOrderCreateTest : BaseTest<GCreateOrderCondition, IHCreateOrderResponse>
    {
        protected override bool RequriedHttps { get { return true; } }
        protected override string Method { get { return "ghotel.order.create"; } }
        protected override bool IsGHotel { get { return true; } }

        protected override GCreateOrderCondition GetRequestCondition()
        {
            if (Condition == null)
            {
                Random rnd = new Random();
                string guestName = "Smith";// +rnd.Next(10, 100);
                DateTime start = DateTime.Now.Date.AddDays(1);
                Condition = new GCreateOrderCondition()
                {

                    AgencyOrderID ="00000019", //Guid.NewGuid().ToString(),
                    ArriveHotelTime = start.AddHours(15),


                    CheckInDate = start,
                    CheckOutDate = start.AddDays(1),
                    Total = 8298.62m,
                    NightlyRateTotal = 3586.8m,
                    AverageBaseRate = 1793.4m,
                    AverageRate = 1793.4m,
                    SurchargeTotal = 634.87m,
                    MaxNightlyRate = 1965.37m,

                    CurrencyCode = "CNY",

                    extraPersonFees = 0m,
                    HotelAddress = "",
                    hotelcity = "",
                    hotelCountry = "USA",
                    HotelID = "266151",
                    HotelName = "Trump International Hotel Las Vegas",
                    HotelTel = "成单前没",
                    
                    RoomNum = 3,

                    IsGurantedOrCharged = 1,

                    CertificateNO = "620105197801121214",
                    CertificateType = IdentityCardType.IdentityCard,
                    ExpiredTime = DateTime.Now.AddYears(5),
                    CreditVerifyCode = 123,
                    //CreditCardNO =  CreditCardEncrypt.Encrypt( "4033910000000000"),
                    HolderName = "travelnow",
                    IsInternationalCard = false,


                    ContactPersonName = "eLong",
                    CreatorIP = "127.0.0.1",
                    AmendorIP = "127.0.0.1",
                    Email = "zhigang.zhao@corp.elong.com",
                    MobileTelephone = "12345678955",
                    Sex = Sex.Male,
                    Telephone = "1234567897",
                    Fax = "12345678907",
                    
                    Remark = "test order",
                    TravelerName = "Tom|Jack",

                    InvoiceFee = 8298.62m,
                    InvoiceTitle = "xxxxxxxxx",

                };

                Condition.InterHotelRoomTypes = new InterHotelRoomType[Condition.RoomNum];
                for (int n = 0; n < Condition.RoomNum; n++)
                {
                    Condition.InterHotelRoomTypes[n] = new InterHotelRoomType()
                    {
                        AdultNum = 2,
                        ChildNum = 0,
                        BedTypeID = 6,
                        BedTypeName = "1大床",
                        GuestName = GetGuestName() + "|" + guestName,
                        RoomTypeName = "特级房",
                        RoomCode = 200202113,
                        RoomTypeID = 227198
                    };
                }
            }

            return Condition;
        }

        public GCreateOrderCondition Condition { get; set; }

        private Random rnd = new Random();

        private string GetGuestName()
        {
            string name = "G";
            string chars = "abcdefghijklmnopqrstuvwxyz";
            int len  = rnd.Next(4,10);
            for (int n = 0; n < len; n++)
            {
                int m = rnd.Next(0, 26);
                name += chars[m];
            }

            return name;
        }
    }
}
