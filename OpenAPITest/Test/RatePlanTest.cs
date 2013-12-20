using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class RatePlanTest : BaseTest<RatePlanCondition, RatePlanResult>
    {

        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "hotel.data.rp"; } }

        protected override RatePlanCondition GetRequestCondition()
        {
            if (Condition == null)
            {
                Condition = new RatePlanCondition()
                {
                    HotelIds = "10101129",
                    PaymentType = EnumPaymentType.Prepay
                };
            }

            return Condition;

        }

        public RatePlanCondition Condition { get; set; }
    }
}
