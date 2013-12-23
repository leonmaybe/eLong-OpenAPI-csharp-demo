using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    class InvValidateTest : BaseTest<ValidateInventoryCondition, ValidateInventoryResult>
    {

        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "hotel.inv.validate"; } }

        protected override ValidateInventoryCondition GetRequestCondition()
        {
            ValidateInventoryCondition condition = new ValidateInventoryCondition()
            {
                 HotelId = "10101129", HotelCode="10101129",
                  RoomTypeId="0001", ArrivalDate= DateTime.Now.AddDays(1),
                 DepartureDate = DateTime.Now.AddDays(2),
                  Amount=100
            };

            return condition;
        }
    }
}
