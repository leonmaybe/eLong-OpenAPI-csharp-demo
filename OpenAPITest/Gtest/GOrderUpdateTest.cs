using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenAPITest.GModel;

namespace OpenAPITest.Gtest
{

    //TODO 修改成功后的结果说明？

    public class GOrderUpdateTest : BaseTest<IHUpdateOrderTravelNameRequest, IHUpdateOrderTravelNameResponse>
    {

        protected override bool RequriedHttps { get { return true; } }
        protected override string Method { get { return "ghotel.order.update"; } }
        protected override bool IsGHotel { get { return true; } }

        protected override IHUpdateOrderTravelNameRequest GetRequestCondition()
        {
            if (Condition == null)
            {

                Condition = new IHUpdateOrderTravelNameRequest()
                {
                    OrderID = 29950428,
                     TravelNameDic = new NamedValue[] {
                        new NamedValue { 
                         Value = "Jackson",
                         Key = "1234", 
                        }
                     }

                };
            }

            return Condition;
        }

        public IHUpdateOrderTravelNameRequest Condition { get; set; }
    }
}
