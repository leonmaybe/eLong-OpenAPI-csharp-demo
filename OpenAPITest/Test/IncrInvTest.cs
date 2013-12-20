using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    class IncrInvTest : BaseTest<IncrCondition, IncrInventoryResult>
    {

        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "hotel.incr.inv"; } }

        protected override IncrCondition GetRequestCondition()
        {
            IncrCondition condition = new IncrCondition()
            {
                LastId = 0
            };

            return condition;
        }
    }
}
