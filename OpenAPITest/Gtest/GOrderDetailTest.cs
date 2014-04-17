using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenAPITest.GModel;

namespace OpenAPITest.Gtest
{
    public class GOrderDetailTest : BaseTest<GOrderDetailCondition, B2BOrderDetail>
    {

        protected override bool RequriedHttps { get { return true; } }
        protected override string Method { get { return "ghotel.order.detail"; } }
        protected override bool IsGHotel { get { return true; } }

        protected override GOrderDetailCondition GetRequestCondition()
        {
            if (Condition == null)
            {

                Condition = new GOrderDetailCondition()
                {
                     OrderID = "29950343"
                };
            }

            return Condition;
        }

        public GOrderDetailCondition Condition { get; set; }
    }
}
