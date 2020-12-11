using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClientTik.WcfService;

namespace WcfClientTik
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new WcfService.Service1Client();

            long id = 17;

            var output = client.GetByIDAsync(id);

            while (!output.IsCompleted)
            {
                Console.WriteLine("Kerkesa po procesohet");

            }

            if (output.IsCompleted)
            {
                Console.WriteLine("Pergjigja erdhi");
            }


            PhoneBookModel model = new PhoneBookModel();
            model.firstName = "Test11_1_1";
            model.lastName = "Surname11_1_1";

            var outputSave = client.SaveAsync(model);

            while (!outputSave.IsCompleted)
            {
                Console.WriteLine("Kerkesa e savimit po procesohet");
            }


            if (outputSave.IsCompleted)
            {
                if (outputSave.Result != null)
                {
                    Console.WriteLine("Pergjigja eshte: " + outputSave.Result.response.responseCode.ToString());
                }
            }

            var outputSearch = client.SearchAsync();

            while (!outputSearch.IsCompleted)
            {
                Console.WriteLine("Kerkesa e searchit po procesohet");
            }

            if (outputSearch.IsCompleted)
            {
                Console.WriteLine("Pergjigja erdhi");
            }




        }
    }
}
