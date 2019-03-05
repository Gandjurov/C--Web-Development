using SoftUniHttpSever.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SoftUniHttpSever
{
    public class HttpServer : IHttpServer
    {
        private bool isWorking;
        private TcpListener tcpListener;

        public HttpServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
        }

        public void Start()
        {
            this.isWorking = true;
            this.tcpListener.Start();

            while (isWorking)
            {
                var client = this.tcpListener.AcceptTcpClient();
                var buffer = new byte[10240];
                var stream = client.GetStream();
                var readLength = stream.Read(buffer, 0, buffer.Length);
                var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
                Console.WriteLine(new string('=', 60));
                Console.WriteLine(requestText);

                var responseBytes = Encoding.UTF8.GetBytes("HTTP/1.0 200 OK" + Environment.NewLine + 
                                                           "Content-Length: 0" + 
                                                           Environment.NewLine + Environment.NewLine);
                stream.Write(responseBytes);
            }

        }

        public void Stop()
        {
            this.isWorking = false;
        }
    }
}
