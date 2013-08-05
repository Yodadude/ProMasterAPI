using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProMasterAPI.Contracts
{
    public class TransactionsHandler
    {
        public static TransactionsResponse Handle(string id)
        {
            string userName = "LBAILLIEU";

            if (!string.IsNullOrWhiteSpace(id))
                userName = id;

            var _db = new NPoco.Database("ProMasterConnection");

            var sql = @"select sd.reference_number, merchant_name, effective_transaction_date, statement_date, amount, original_currency_amount, 
                          isnull(cc.currency_type, sd.original_currency_code) as currency_type, case cc.currency_type when 'EUR' then '€' when 'GBP' then '£' else '$' end as currency_symbol,
                          tt.description, mt.merchant_type, mt.description
                        from statement_data sd 
                          inner join card_account ca on ca.card_account_number = sd.card_account_number
                          inner join wf_instance_status wi on wi.instance_id = sd.reference_number
                          inner join wf_activities wa on wa.activity_id = wi.activity_id
                          left outer join transaction_types tt on tt.card_type = sd.card_type and tt.transaction_code = sd.transaction_code
                          left outer join merchant_types mt on mt.card_type = sd.card_type and mt.merchant_type = sd.merchant_category_type
                          left outer join currency_codes cc on cc.card_type = sd.card_type and cc.currency_code = sd.original_currency_code
                         where ca.user_name = @0
                           and wa.activity_type = 103
                         order by sd.effective_transaction_date";

            var list = _db.Fetch<TransactionDetails>(sql, userName);

            return new TransactionsResponse { Result = list };
        }
    }

    public class TransactionDetails
    {
        public string id { get; set; }
        public string merchantName { get; set; }
        public DateTime purchaseDate { get; set; }
        public DateTime statementDate { get; set; }
        public decimal amount { get; set; }
        public decimal foreignAmount { get; set; }
        public string foreignCurrency { get; set; }
        public string foreignCurrencySymbol { get; set; }
        public string notes { get; set; }
        public string transactionType { get; set; }
        public string merchantType { get; set; }
        public string merchantCode { get; set; }
    }
}
