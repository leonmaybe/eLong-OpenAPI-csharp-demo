using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class InventoryTest : BaseTest<InventoryCondition, InventoryResult>
    {

        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "hotel.data.inventory"; } }

        protected override InventoryCondition GetRequestCondition()
        {
            if (Condition == null)
            {
                Condition = new InventoryCondition()
                {
                    StartDate = DateTime.Now.Date.AddDays(0),
                    EndDate = DateTime.Now.Date.AddDays(0),
                    HotelIds = "20101487", RoomTypeId ="0006"
                };
            }
            return Condition;
        }

        public InventoryCondition Condition { get; set; }
    }
}
