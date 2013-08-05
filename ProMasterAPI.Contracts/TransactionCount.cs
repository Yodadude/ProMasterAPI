using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.ServiceHost;


namespace ProMasterAPI.Contracts
{
    [Route("/badges")]
    public class TransactionCount : IReturn<TransactionCountResponse>
    {
        
    }
}
