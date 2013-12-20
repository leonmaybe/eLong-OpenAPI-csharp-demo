using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class OrderListTest : BaseTest<OrderListCondition, OrderListResult>
    {

        protected override bool RequriedHttps { get { return true; } }

        protected override string Method { get { return "hotel.order.list"; } }

        protected override OrderListCondition GetRequestCondition()
        {
            OrderListCondition condition = new OrderListCondition()
            {

                CreationTimeFrom = DateTime.Now.Date.AddDays(-2),
                CreationTimeTo = DateTime.Now.Date.AddDays(1),
                
            };

            return condition;
        }
    }
}
