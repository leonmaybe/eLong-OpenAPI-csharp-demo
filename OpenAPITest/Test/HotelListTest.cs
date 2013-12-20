using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class HotelListTest : BaseTest<HotelListCondition, HotelList>
    {
        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "hotel.list"; } }

        protected override HotelListCondition GetRequestCondition()
        {
            HotelListCondition condition = new HotelListCondition()
            {
                ArrivalDate = DateTime.Now.Date.AddDays(0),
                DepartureDate = DateTime.Now.Date.AddDays(1),
                CityId = "0101",
                
                //PaymentType = EnumPaymentType.Prepay,
                ProductProperties = EnumProductProperty.LimitedTimeSale,
                PageIndex = 1,
                PageSize = 10,
                 ResultType="1,2,3",
                  
            };

            return condition;
        }
    }
}
