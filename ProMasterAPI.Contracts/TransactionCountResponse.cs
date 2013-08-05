using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace ProMasterAPI.Contracts
{
    public class TransactionCountResponse
    {
        private readonly IDatabase _db;

        public StatusCount Result { get; set; }

        public TransactionCountResponse(string id = "LBAILLIEU")
        {
            _db = new NPoco.Database("ProMasterConnection");

            var sql = @"SELECT a.status, SUM(u.reccount) as count
                          FROM user_wf_counts u 
	                         INNER JOIN wf_activities a ON u.activity_id = a.activity_id 
                         WHERE u.user_name = @0
                           AND activity_type IN (103)
                           AND object_group IN ('E','T')
                        GROUP BY a.status";

            var list = _db.Fetch<StatusCount>(sql, id).SingleOrDefault();

            Result = new StatusCount { Status = list.Status, Count = list.Count };

        }

    }

    public class StatusCount
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }
}
