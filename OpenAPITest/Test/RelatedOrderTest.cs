using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class RelatedOrderTest : BaseTest<RelatedOrderCondition, RelatedOrderResult>
    {

        protected override bool RequriedHttps { get { return true; } }

        protected override string Method { get { return "hotel.order.related"; } }

        protected override RelatedOrderCondition GetRequestCondition()
        {
            RelatedOrderCondition condition = new RelatedOrderCondition()
            {
                OrderIds = "43148629", RelationType = EnumOrderRelationType.Child
            };

            return condition;
        }
    }
}
