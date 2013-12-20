using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OpenAPITest
{
    [XmlRoot("ApiResult")]
    public class BaseResponse<T>
    {
        public string Code { get; set; }
        public T Result { get; set; }
        public T Data { get; set; }
    }
}
