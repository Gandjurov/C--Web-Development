using SoftUniHttpSever.Contracts;
using System;
using System.Net;

namespace SoftUniHttpSever
{
    public class StartUp
    {
        public static void Main()
        {
            //IHttpServer server = new HttpServer();

            //server.Start();

            var inputString = WebUtility.UrlDecode(Console.ReadLine());
            var uri = new Uri(inputString);
            var uriScheme = uri.Scheme;
            var uriServer = uri.Segments;

            Console.WriteLine($"[Protocol] = {uriScheme}");
            Console.WriteLine($"[Protocol] = {uriServer}");

        }
    }
}
