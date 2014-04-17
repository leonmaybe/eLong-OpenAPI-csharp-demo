using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    class RecentOrderTest : BaseTest<HotelIdsCondition, RecentOrderTimeResult>
    {

        protected override bool RequriedHttps { get { return true; } }

        protected override string Method { get { return "hotel.order.recent"; } }

        protected override HotelIdsCondition GetRequestCondition()
        {
            HotelIdsCondition condition = new HotelIdsCondition()
            {
                 HotelIds = "40101025"
            };

            return condition;
        }
    }
}
