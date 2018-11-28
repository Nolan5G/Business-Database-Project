using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Models
{
    class LoanPaymentVO
    {
        int id;
        int loan_id;
        double payment_amount;

        public LoanPaymentVO(int id, int loan_id, double payment_amount)
        {
            this.Id = id;
            this.Loan_id = loan_id;
            this.Payment_amount = payment_amount;
        }

        public int Id { get => id; set => id = value; }
        public int Loan_id { get => loan_id; set => loan_id = value; }
        public double Payment_amount { get => payment_amount; set => payment_amount = value; }
    }
}
