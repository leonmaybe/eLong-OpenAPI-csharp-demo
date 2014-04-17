using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class OrderDetailTest : BaseTest<OrderIdsCondition, OrderDetailResult>
    {

        protected override bool RequriedHttps { get { return true; } }

        protected override string Method { get { return "hotel.order.detail"; } }

        protected override OrderIdsCondition GetRequestCondition()
        {
            OrderIdsCondition condition = new OrderIdsCondition()
            {
                OrderId = 69728823
            };

            return condition;
        }
    }
}
