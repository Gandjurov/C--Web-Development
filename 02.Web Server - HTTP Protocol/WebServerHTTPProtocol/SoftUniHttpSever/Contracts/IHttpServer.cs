using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniHttpSever.Contracts
{
    public interface IHttpServer
    {
        void Start();

        void Stop();
    }
}
