using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class UpdateOrderTest : BaseTest<UpdateOrderCondition, UpdateOrderResult>
    {

        protected override bool RequriedHttps { get { return true; } }

        protected override string Method { get { return "hotel.order.update"; } }

        protected override UpdateOrderCondition GetRequestCondition()
        {
            UpdateOrderCondition condition = new UpdateOrderCondition()
            {
                OrderId = 67740066,
                NumberOfCustomers = 1,
                NumberOfRooms = 1,
                //RatePlanId = 1,
                RoomTypeId = "0002", Contact = new Contact{ Mobile="13100000001", Name="航想"},
                ArrivalDate = DateTime.Now.AddDays(10),
                DepartureDate = DateTime.Now.AddDays(11)
            };

            return condition;
        }
    }
} 
