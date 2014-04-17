using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class PerformanceTest : BaseTest<HotelListCondition, string>
    {
        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "hotel.test"; } }

        protected override HotelListCondition GetRequestCondition()
        {
            HotelListCondition condition = new HotelListCondition()
            {
                ArrivalDate = DateTime.Now.Date.AddDays(1),
                DepartureDate = DateTime.Now.Date.AddDays(2),
                CityId = "0101",
                PageIndex = 0,
                PageSize = 3
            };

            return condition;
        }
    }
}