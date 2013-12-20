using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.GModel
{
    public class GHotelRoomAvalilableCondition
    {
        public string checkInDate { get; set; }
        public string checkOutDate { get; set; }
        public string hotelID { get; set; }
        public bool includeDetails { get; set; }
        public List<Room> RoomGroup { get; set; }


    }

    
}
