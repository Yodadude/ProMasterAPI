using ServiceStack.ServiceInterface;
using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Funq;
using ProMasterAPI.Contracts;
using NPoco;

namespace ProMasterAPI
{
    public class ProMasterAPIService : Service
    {
        
        public object Get(TransactionCount request)
        {
            return TransactionCountHandler.Handle(request.Name);
        }

        public object Get(Transactions request)
        {
            return TransactionsHandler.Handle(request.Name);
        }
    }

    public class AppHost : AppHostBase
    {
        public AppHost() : base("ProMaster Web API Services", typeof(ProMasterAPIService).Assembly) { }

        public override void Configure(Container container)
        {
            Routes.Add<TransactionCount>("/badges");
            Routes.Add<TransactionCount>("/badges/{Name}");
            Routes.Add<Transactions>("/transactions");
            Routes.Add<Transactions>("/transactions/{Name}");
        }
    }


}