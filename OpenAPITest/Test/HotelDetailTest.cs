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
                    ArrivalDate = DateTime.Now.Date.AddDays(7),
                    DepartureDate = DateTime.Now.Date.AddDays(8),
                    //HotelIds = "41201343,51201015,51201082,51221119,51201124,51201112,31201074,51201116,51201164,01201161",
                    HotelIds = "40101008",
                    //RoomTypeId = "0009",
                    //RoomTypeId = "1128", 
                    //RatePlanId = 145742,

                    //PaymentType = EnumPaymentType.Prepay,
                    // Options = "1,2,3"
                };
            }

            return Condition;
        }

        public HotelDetailCondition Condition { get; set; }
    }
}
