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
                    StartDate = DateTime.Now.Date.AddDays(1),
                    EndDate = DateTime.Now.Date.AddDays(3),
                    HotelIds = "02501374",
                };
            }
            return Condition;
        }

        public InventoryCondition Condition { get; set; }
    }
}
