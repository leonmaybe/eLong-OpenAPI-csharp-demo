using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.GModel
{
    public class GHotelListCondition
    {
        public string checkInDate { get; set; }
        public string checkOutDate { get; set; }
        public string destinationId { get; set; }
        public Room[] RoomGroup { get; set; }

        public string amenities { get; set; }
        public string hotelIdList { get; set; }
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }
        public int maxRate { get; set; }
        public float maxStarRating { get; set; }
        public int minRate { get; set; }
        public float minStarRating { get; set; }
        public string propertyName { get; set; }
        public int searchRadius { get; set; }
        public EnumSortType sort { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

    }
}
