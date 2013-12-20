using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class ValidateTest : BaseTest<ValidateCondition, ValidateResult>
    {
        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "hotel.data.validate"; } }

        protected override ValidateCondition GetRequestCondition()
        {
            if (Condition == null)
            {
                var ArrivalDate = DateTime.Now.Date.AddDays(4);
                Condition = new ValidateCondition()
               {
                   ArrivalDate = DateTime.Now.Date.AddDays(4),
                   DepartureDate = DateTime.Now.Date.AddDays(5),
                   HotelId = "10101129",
                   RoomTypeId = "0001",
                   RatePlanId = 145742,
                   TotalPrice = 400M * 1,
                   NumberOfRooms = 1,
                   EarliestArrivalTime = ArrivalDate.AddHours(17),
                   LatestArrivalTime = ArrivalDate.AddHours(19)
               };
            }

            return Condition;
        }

        public ValidateCondition Condition { get; set; }
    }
}
