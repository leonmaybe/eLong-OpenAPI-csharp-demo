using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class RateTest : BaseTest<RateCondition, RateResult>
    {
        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "hotel.data.rate"; } }

        protected override RateCondition GetRequestCondition()
        {
            if (Condition == null)
            {
                Condition = new RateCondition()
                {
                    StartDate = DateTime.Now.Date.AddDays(1),
                    EndDate = DateTime.Now.Date.AddDays(4),
                    HotelIds = "02501374",
                    //PaymentType = EnumPaymentType.SelfPay
                };
            }

            return Condition;
        }

        public RateCondition Condition { get; set; }
    }
}
