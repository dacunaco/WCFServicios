using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServicios
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public double UnitPrice { get; set; }

        [DataMember]
        public int Stock { get; set; }

        [DataMember]
        public string Category { get; set; }
    }
}