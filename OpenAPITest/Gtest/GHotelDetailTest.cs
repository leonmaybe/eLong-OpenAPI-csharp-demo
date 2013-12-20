using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenAPITest.GModel;

namespace OpenAPITest.Gtest
{
    public class GHotelDetailTest : BaseTest<GHotelDetailCondition, EanDetailResponse>
    {
        protected override bool RequriedHttps { get { return false; } }
        protected override string Method { get { return "ghotel.search.detail"; } }
        protected override bool IsGHotel { get { return true; } }

        protected override GHotelDetailCondition GetRequestCondition()
        {
            if (Condition == null)
            {

                Condition = new GHotelDetailCondition()
                {
                    hotelId = "414787", // "164116",
                     
                };
            }

            return Condition;
        }

        public GHotelDetailCondition Condition { get; set; }
    }
}
