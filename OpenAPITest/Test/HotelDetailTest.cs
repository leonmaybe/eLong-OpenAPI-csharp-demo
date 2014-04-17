using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class HotelDetailTest : BaseTest<HotelDetailCondition, HotelList>
    {
        protected override bool RequriedHttps { get { return false; } }
        protected override string Method { get { return "hotel.detail"; } }

        protected override HotelDetailCondition GetRequestCondition()
        {
            if (Condition == null)
            {
                Condition = new HotelDetailCondition()
                {
                    ArrivalDate = DateTime.Now.Date.AddDays(1),
                    DepartureDate = DateTime.Now.Date.AddDays(3),
                    //HotelIds = "41201343,51201015,51201082,51221119,51201124,51201112,31201074,51201116,51201164,01201161",
                    HotelIds = "10101129",
                    //RoomTypeId = "0001",
                    //RoomTypeId = "1128", 
                    //RatePlanId = 245839,

                    //PaymentType = EnumPaymentType.SelfPay,
                    // Options = "1,2,3"
                   
                };
            }

            return Condition;
        }

        public HotelDetailCondition Condition { get; set; }
    }
}
