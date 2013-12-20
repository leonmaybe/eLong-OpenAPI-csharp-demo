using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenAPITest.GModel;


namespace OpenAPITest.Gtest
{
    public class GRoomAvailableTest : BaseTest<GHotelRoomAvalilableCondition, HotelRoomResponse[]>
    {
        protected override bool RequriedHttps { get { return false; } }
        protected override string Method { get { return "ghotel.search.room"; } }
        protected override bool IsGHotel { get { return true; } }

        protected override GHotelRoomAvalilableCondition GetRequestCondition()
        {
            if (Condition == null)
            {
                Condition = new GHotelRoomAvalilableCondition()
                {
                    hotelID = "266151",// "144875",
                    checkInDate = "07/26/2013",
                    checkOutDate = "07/29/2013",
                    includeDetails = true,
                    RoomGroup = new List<OpenAPITest.GModel.Room>() {
                    new OpenAPITest.GModel.Room(){
                     numberOfAdults = 2, numberOfChildren = 0
                   }
                }   
                    
                };
            }

            return Condition;
        }

        public GHotelRoomAvalilableCondition Condition { get; set; }

        protected override void ActionAfterTest(HotelRoomResponse[] response)
        {
            if (response != null && response.Length > 0)
            {
                var obj = response[0];


                if (obj != null && obj.ValueAdds != null && obj.ValueAdds.Length > 0)
                {
                    foreach (var va in obj.ValueAdds)
                    {
                        Console.WriteLine(va.id + "---" + va.description);
                    }
                }

            }
        }

    }
}
