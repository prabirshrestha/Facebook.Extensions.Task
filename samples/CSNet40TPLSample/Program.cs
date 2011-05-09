using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;

namespace CSNet40TPLSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteAsyncMethod();            

            Console.ReadKey();
        }

        private static void ExecuteAsyncMethod()
        {
            var fb = new FacebookClient();
            var task = fb.GetTaskAsync("/4");

            task.ContinueWith(
                t =>
                {
                    if (t.Exception == null)
                    {
                        dynamic result = t.Result;
                        Console.WriteLine("Hi {0}", result.name);
                    }
                    else
                    {
                        Console.WriteLine("error occurred");
                    }
                });
        }
    }
}
