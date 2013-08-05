using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;


namespace ProMasterAPI.Contracts
{
    public class TransactionCount : IReturn<TransactionCountResponse>
    {
        public string Name { get; set; }
    }
}
