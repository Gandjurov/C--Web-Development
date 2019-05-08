using SoftUniHttpSever.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoftUniHttpSever
{
    public class HttpServer : IHttpServer
    {
        private bool isWorking;
        private TcpListener tcpListener;

        public HttpServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 80);
        }

        public void Start()
        {
            this.isWorking = true;
            this.tcpListener.Start();
            Console.WriteLine("Started...");

            while (isWorking)
            {
                var client = this.tcpListener.AcceptTcpClient();
                Task.Run(() => ProcessClient(client));
            }

        }

        private static async void ProcessClient(TcpClient client)
        {
            var buffer = new byte[10240];
            var stream = client.GetStream();
            Console.WriteLine($"{client.Client.RemoteEndPoint} => {Thread.CurrentThread.ManagedThreadId}");
            var readLength = await stream.ReadAsync(buffer, 0, buffer.Length);
            Console.WriteLine($"{client.Client.RemoteEndPoint} => {Thread.CurrentThread.ManagedThreadId}");
            var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
            //Console.WriteLine(new string('=', 60));
            //Console.WriteLine(requestText);
            await Task.Run(() => Thread.Sleep(10000));
            var responseText = File.ReadAllText("index.html");

            var responseBytes = Encoding.UTF8.GetBytes("HTTP/1.0 200 OK" + Environment.NewLine +
                                                       "Location: https://softuni.bg" + Environment.NewLine + Environment.NewLine +
                                                       "Content-Type: text/html" + Environment.NewLine +
                                                       "Content-Disposition: attachment; filename=index.html" + Environment.NewLine +
                                                       "Content-Length: " + responseText.Length +
                                                       Environment.NewLine + Environment.NewLine +
                                                       responseText);
            stream.Write(responseBytes);
            Console.WriteLine($"{client.Client.RemoteEndPoint} => {Thread.CurrentThread.ManagedThreadId}");
            //Thread.Sleep(10000);
            await stream.WriteAsync(Encoding.UTF8.GetBytes("<h1>@</h1>"));
        }

        public void Stop()
        {
            this.isWorking = false;
        }
    }
}
