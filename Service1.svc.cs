using Phone_Book_DB;
using Phone_Book_DB.Services;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly PhoneBookServicesDb servicesDb = new PhoneBookServicesDb();


        #region Sync Method
        public string GetData(int value)
        {
            if (servicesDb.IsConnected())
            { 

                return string.Format("You entered: {0}", value);
            }

            return "Probleme ";
        }

        #endregion

        #region  AsyncMethod
        public IAsyncResult BeginGetByID(long id, AsyncCallback callback, object asyncState)
        {
            Output output = new Output();
            try
            {
                if (id > 0)
                {
                  var item=servicesDb.GetById(id);

                    PhoneBookModel model = new PhoneBookModel();
                    model.Presect(item);
                    output.lstPhoneBookModel.Add(model);
                    output.response.responseCode = ResponseCode.OK;
                }
            }
          
            catch(Exception ex)
            {
                output.response.responseCode = ResponseCode.KO;
                output.response.errorMessage = $"Mesazhi i errorit eshte :{ex.ToString()}";
            }

            return new CompletedAsyncResult<Output>(output);
        }

        public Output EndGetByID(IAsyncResult r)
        {
            CompletedAsyncResult<Output> result = r as CompletedAsyncResult<Output>;
            return result.Data;
        }

        public IAsyncResult BeginSave(PhoneBookModel model, AsyncCallback callback, object asyncState)
        {
            Output output = new Output();
            try
            {
                if (model != null)
                {
                    T_PHONE_BOOK item = new T_PHONE_BOOK();
                    model.Fill(item);
                    if (servicesDb.Save(item))
                    {
                        output.response.responseCode = ResponseCode.OK;
                    }
                    else
                    {
                        output.response.responseCode = ResponseCode.KO;
                        output.response.errorMessage = "Probleme gjate shtimit";
                    }
                }

            }
            catch(Exception ex)
            {
                output.response.responseCode = ResponseCode.KO;
                output.response.errorMessage = $"Errori eshte {ex.ToString()}";
            }

            return new CompletedAsyncResult<Output>(output);

        }

        public Output EndSave(IAsyncResult r)
        {
            CompletedAsyncResult<Output> result = r as CompletedAsyncResult<Output>;
            return result.Data;
        }

        public IAsyncResult BeginSearch( AsyncCallback callback, object asyncState)
        {
            Output output = new Output();
            try
            {
                var lst = servicesDb.Search();
                if(lst!=null)
                {
                    foreach(var item in lst)
                    {
                        PhoneBookModel model = new PhoneBookModel();
                        model.Presect(item);
                        output.lstPhoneBookModel.Add(model);
                    }
                }

                output.response.responseCode = ResponseCode.OK;

            }
            catch (Exception ex)
            {
                output.response.responseCode = ResponseCode.KO;
                output.response.errorMessage = $"Errori eshte {ex.ToString()}";
            }

            return new CompletedAsyncResult<Output>(output);





        }

        public Output EndSearch(IAsyncResult r)
        {
            CompletedAsyncResult<Output> result = r as CompletedAsyncResult<Output>;
            return result.Data;
        }

        #endregion
    }
}
