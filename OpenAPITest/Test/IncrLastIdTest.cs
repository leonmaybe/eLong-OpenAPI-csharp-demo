using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class IncrLastIdTest : BaseTest<IncrLastIdCondition, LastIdResult>
    {

        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "hotel.incr.id"; } }

        protected override IncrLastIdCondition GetRequestCondition()
        {
            IncrLastIdCondition condition = new IncrLastIdCondition()
            {
                LastTime = DateTime.Parse("2013-07-11 00:03:04"),
                IncrType = EnumIncrType.Inventory
            };

            return condition;
        }
    }
}
