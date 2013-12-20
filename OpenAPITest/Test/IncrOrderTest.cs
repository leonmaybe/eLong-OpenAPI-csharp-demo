using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    class IncrOrderTest : BaseTest<IncrCondition, IncrOrderResult>
    {

        protected override bool RequriedHttps { get { return true; } }

        protected override string Method { get { return "hotel.incr.order"; } }

        private long _lastId = 281475955781000;

        protected override IncrCondition GetRequestCondition()
        {
            IncrCondition condition = new IncrCondition()
            {
                LastId = _lastId
            };

            return condition;
        }

        public void SetLastId(long lastId)
        {
            _lastId = lastId;
        }
    }
}
