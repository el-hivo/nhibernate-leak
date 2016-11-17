using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace NHibernateLeak.LoadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:1732");

            

            for (int i = 1; i < 1000; i++)
            {
                var request = new RestRequest(i + "/Query/Get", Method.GET);
                Console.WriteLine("Executing request " + i);
                client.Execute(request);
            }
        }
    }
}
