using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace ProMasterAPI.Contracts
{
    public class TransactionCountHandler
    {
        public static TransactionCountResponse Handle(string id)
        {
            string userName = "LBAILLIEU";

            if (!string.IsNullOrWhiteSpace(id))
                userName = id;

            var _db = new NPoco.Database("ProMasterConnection");
            
            var sql = @"SELECT a.status, SUM(u.reccount) as count
                          FROM user_wf_counts u 
	                         INNER JOIN wf_activities a ON u.activity_id = a.activity_id 
                         WHERE u.user_name = @0
                           AND activity_type IN (103)
                           AND object_group IN ('E','T')
                        GROUP BY a.status";

            var data = _db.Fetch<StatusCount>(sql, userName).SingleOrDefault();

            return new TransactionCountResponse { Status = data.Status, Count = data.Count };
        }
    }

    public class StatusCount
    {
        public string Status { get; set; }
        public int Count { get; set; }
    }
}
