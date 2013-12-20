using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class FeedbackTest : BaseTest<CheckInFeedbackCondition, CheckInFeedbackResult>
    {
        protected override bool RequriedHttps { get { return true; } }
        protected override string Method { get { return "hotel.order.feedback"; } }

        protected override CheckInFeedbackCondition GetRequestCondition()
        {
            if (Condition == null)
            {
                Condition = new CheckInFeedbackCondition()
                {
                    CustomerName = "张三丰",
                    Notes = "",
                    OrderId = 43123443
                };
            }

            return Condition;
        }

        public CheckInFeedbackCondition Condition { get; set; }
    }
}