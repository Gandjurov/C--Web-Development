using SoftUniHttpSever.Contracts;
using System;

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
