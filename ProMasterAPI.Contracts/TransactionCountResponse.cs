﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace ProMasterAPI.Contracts
{
    public class TransactionCountResponse
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }
}
