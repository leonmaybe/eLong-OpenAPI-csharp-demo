using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class CancelOrderTest : BaseTest<CancelOrderCondition, CancelOrderResult>
    {

        protected override bool RequriedHttps { get { return true; } }

        protected override string Method { get { return "hotel.order.cancel"; } }

        protected override CancelOrderCondition GetRequestCondition()
        {
            CancelOrderCondition condition = new CancelOrderCondition()
            {
                OrderId = 43148629
            };

            return condition;
        }
    }
}
