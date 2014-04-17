using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest
{
    class InstantOrderTest : BaseTest<OrderIdCondition, InstantOrderResult>
    {

        protected override bool RequriedHttps { get { return true; } }

        protected override string Method { get { return "hotel.order.instant"; } }

        protected override OrderIdCondition GetRequestCondition()
        {
            OrderIdCondition condition = new OrderIdCondition()
            {
                OrderId = 71226531
            };

            return condition;
        }
    }
}
