using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfTIK.Models
{
    [DataContract]
    [Serializable]
    public class PhoneBookModel
    {
        [DataMember]
        public long? id { get; set; }

        [DataMember]
        public string firstName { get; set; }  //pascal case (FirstName) --> camel case (firstName)

        [DataMember]
        public string lastName { get; set; }  //pascal case --> camel case

    }
}