using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPomeriggioPrism.Services
{
    public interface IApplicationContext
    {
        string GetReqResAdress();

        void SetReqResAdress(string ReqResAdress);
    }
}
