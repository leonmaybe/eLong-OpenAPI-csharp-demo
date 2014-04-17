using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class IncrStateTest : BaseTest<IncrCondition, IncrStateResult>
    {

        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "hotel.incr.state"; } }

        protected override IncrCondition GetRequestCondition()
        {
            IncrCondition condition = new IncrCondition()
            {
                LastId = 1
            };

            return condition;
        }
    }
}
