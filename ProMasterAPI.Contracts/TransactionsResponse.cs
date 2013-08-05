using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace ProMasterAPI.Contracts
{
    public class TransactionsResponse
    {
        public List<TransactionDetails> Result { get; set; }
    }
}
