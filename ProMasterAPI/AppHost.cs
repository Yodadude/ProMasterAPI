using ServiceStack.ServiceInterface;
using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Funq;
using ProMasterAPI.Contracts;

namespace ProMasterAPI
{
    public class ProMasterAPIService : Service
    {
        public object Any(TransactionCount request)
        {
            return new TransactionCountResponse();
        }
    }

    public class AppHost : AppHostBase
    {
        public AppHost() : base("ProMaster Web API Services", typeof(ProMasterAPIService).Assembly) { }

        public override void Configure(Container container)
        {
            Routes.Add<TransactionCount>("/badges");
        }
    }
}