using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    class ExchangeRateTest : BaseTest<ExchangeRateCondition, ExchangeRateResult>
    {

        protected override bool RequriedHttps { get { return false; } }

        protected override string Method { get { return "common.exchangerate"; } }

        protected override ExchangeRateCondition GetRequestCondition()
        {
            ExchangeRateCondition condition = new ExchangeRateCondition()
            {
                 CurrencyId = EnumCurrencyCode.HKD
            };

            return condition;
        }
    }
}
