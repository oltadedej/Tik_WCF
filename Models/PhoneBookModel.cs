using Phone_Book_DB;
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


        public void Fill(T_PHONE_BOOK item)
        {

            if (this != null)
            {
                if (!String.IsNullOrEmpty(this.firstName))
                {
                    item.NAME = this.firstName;

                }
                if (!String.IsNullOrEmpty(this.lastName))
                {
                    item.SURNAME = this.lastName;
                }
            }

        }

        public void Presect(T_PHONE_BOOK item)
        {

            if (item != null)
            {
                this.firstName = item.NAME;
                this.lastName = item.SURNAME;
            }
        }


    }
}