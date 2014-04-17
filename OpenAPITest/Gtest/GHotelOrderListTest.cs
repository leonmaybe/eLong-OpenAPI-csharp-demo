using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenAPITest.GModel;


namespace OpenAPITest.Gtest
{
    public class GHotelOrderListTest : BaseTest<IHOrderSearchRequest, B2BOrder>
    {
        protected override bool RequriedHttps { get { return true; } }
        protected override string Method { get { return "ghotel.order.list"; } }
        protected override bool IsGHotel { get { return true; } }

        protected override IHOrderSearchRequest GetRequestCondition()
        {
            if (Condition == null)
            {
                Condition = new IHOrderSearchRequest()
                {
                     
                    Status = 1,
                    
                

                };
            }

            return Condition;
        }

        public IHOrderSearchRequest Condition { get; set; }

    }
}
