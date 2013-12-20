using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenAPITest.GModel;

namespace OpenAPITest.Gtest
{
    public class GHotelListTest : BaseTest<GHotelListCondition, EanListResponse>
    {
        protected override bool RequriedHttps { get { return false; } }
        protected override string Method { get { return "ghotel.search.list"; } }
        protected override bool IsGHotel { get { return true; } }

        protected override GHotelListCondition GetRequestCondition()
        {
            if (Condition == null)
            {

                Condition = new GHotelListCondition()
                {
                    checkInDate = "08/27/2013",  //"2013-08-04" , //
                    checkOutDate = "08/28/2013",  // "2013-08-05", //
                    hotelIdList = "412162",// "144875,164116,144875",
                    destinationId = "2EBABFD7-C0B7-4EDC-A830-BE4D93D426FF",// "Seattle",
                     
                    pageIndex = 1,
                    pageSize = 10,
                    minStarRating=3,
                    maxStarRating=5,
                     
                    RoomGroup = new OpenAPITest.GModel.Room[1] {
                        new OpenAPITest.GModel.Room(){
                         numberOfAdults = 2, numberOfChildren = 0
                       }
                   }
                };
            }

            return Condition;
        }

        public GHotelListCondition Condition { get; set; }
    }
}
