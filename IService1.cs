using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfTIK.Models;

namespace WcfTIK
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        #region Sync Method

        [OperationContract]
        [WebInvoke(Method = "GET",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "GetData?Id={value}")]
        string GetData(int value);

       

        #endregion
        #region
        [OperationContractAttribute(AsyncPattern = true)]
        IAsyncResult BeginGetByID(long id, AsyncCallback callback, object asyncState);

        //Note: There is no OperationContractAttribute for the end method.
        Output EndGetByID(IAsyncResult result);



        [OperationContractAttribute(AsyncPattern = true)]
        IAsyncResult BeginSave(PhoneBookModel model, AsyncCallback callback, object asyncState);

        //Note: There is no OperationContractAttribute for the end method.
        Output EndSave(IAsyncResult result);




        [OperationContractAttribute(AsyncPattern = true)]
        IAsyncResult BeginSearch(AsyncCallback callback, object asyncState);

        //Note: There is no OperationContractAttribute for the end method.
        Output EndSearch(IAsyncResult result);


        #endregion


    }


  
}
