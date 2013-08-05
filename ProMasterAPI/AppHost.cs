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

    }

    public class AppHost : AppHostBase
    {
        public AppHost() : base("Hello Web Services", typeof(ProMasterAPIService).Assembly) { }

        public override void Configure(Container container)
        {
            Routes.Add<TransactionCount>("/badges");
        }
    }
}