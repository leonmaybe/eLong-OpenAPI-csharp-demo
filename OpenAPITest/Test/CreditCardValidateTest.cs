using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest.Test
{
    public class CreditCardValidateTest : BaseTest<ValidateCreditCardCondition, ValidateCreditCardResult>
    {
        protected override bool RequriedHttps { get { return true; } }
        protected override string Method { get { return "common.creditcard.validate"; } }

        protected override ValidateCreditCardCondition GetRequestCondition()
        {
            if (Condition == null)
            {
                Condition = new ValidateCreditCardCondition()
                {
                     CreditCardNo = ""
                };
            }

            return Condition;
        }

        public ValidateCreditCardCondition Condition { get; set; }
    }
}
