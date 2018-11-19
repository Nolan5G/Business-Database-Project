using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Models
{
    class AccountTransactionVO
    {
        private double amount;
        private string status;
        private string timestamp;

        public AccountTransactionVO(double amount, string status, string timestamp)
        {
            this.Amount = amount;
            this.status = status;
            this.Timestamp = timestamp;
        }

        public double Amount { get => amount; set => amount = value; }
        public string Status { get => status; set => status = value; }
        public string Timestamp { get => timestamp; set => timestamp = value; }
    }
}
