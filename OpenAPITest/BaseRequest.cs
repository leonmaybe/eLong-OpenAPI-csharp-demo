using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenAPITest
{
    public class BaseRequest<T>
    {
        public double Version { get; set; }
        public EnumLocal Local { get; set; }

        public T Request { get; set; }
    }
}
