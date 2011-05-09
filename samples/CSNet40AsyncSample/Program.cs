using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;

namespace CSNet40AsyncSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteAsyncMethod();

            Console.ReadKey();
        }

        private async static void ExecuteAsyncMethod()
        {
            var fb = new FacebookClient();

            try
            {
                dynamic result = await fb.GetTaskAsync("/4");

                Console.WriteLine("Name: {0}", result.name);
            }
            catch (FacebookApiException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
