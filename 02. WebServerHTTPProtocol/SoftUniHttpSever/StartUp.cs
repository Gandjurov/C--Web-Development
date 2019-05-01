using SoftUniHttpSever.Contracts;
using System;
using System.Net;

namespace SoftUniHttpSever
{
    public class StartUp
    {
        public static void Main()
        {
            IHttpServer server = new HttpServer();

            server.Start();

        }
    }
}
