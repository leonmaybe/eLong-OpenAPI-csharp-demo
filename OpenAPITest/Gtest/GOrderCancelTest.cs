using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenAPITest.GModel;


//TODO 取消没有对应的罚金返回？？

namespace OpenAPITest.Gtest
{
    public class GOrderCancelTest : BaseTest<IHOrderCancelRequest, IHOrderCacelResponse>
    {
        protected override bool RequriedHttps { get { return true; } }
        protected override string Method { get { return "ghotel.order.cancel"; } }
        protected override bool IsGHotel { get { return true; } }

        protected override IHOrderCancelRequest GetRequestCondition()
        {
            if (Condition == null)
            {
                Condition = new IHOrderCancelRequest()
                {

                    OrderID = 32440331,
                     CancelTypeCode = "天气",
                      CancelReason = "没法到达", ConfirmCode = "1234"
                     

                };
            }

            return Condition;
        }

        public IHOrderCancelRequest Condition { get; set; }

    }
}
