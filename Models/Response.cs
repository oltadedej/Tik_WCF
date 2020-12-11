using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfTIK.Models
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public string errorMessage { get; set; }

        [DataMember]
        public ResponseCode responseCode { get; set; }
    }
}