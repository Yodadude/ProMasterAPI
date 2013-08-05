using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;


namespace ProMasterAPI.Contracts
{
    public class Transactions : IReturn<TransactionsResponse>
    {
        public string Name { get; set; }
    }
}