using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Models
{
    class LoanApplicationVO
    {
        private int loadId;
        private int accountId;
        private int branchManagerId;
        private double principalAmount;
        private string loanType;
        private double interest;
        private string socialSecurity;
        private int creditScore;
        private string creationTime;

        public LoanApplicationVO(int loadId, int accountId, int branchManagerId, double principalAmount, string loanType, double interest, string socialSecurity, int creditScore, string creationTime)
        {
            this.LoadId = loadId;
            this.AccountId = accountId;
            this.BranchManagerId = branchManagerId;
            this.PrincipalAmount = principalAmount;
            this.LoanType = loanType;
            this.Interest = interest;
            this.SocialSecurity = socialSecurity;
            this.CreditScore = creditScore;
            this.CreationTime = creationTime;
        }

        public int LoadId { get => loadId; set => loadId = value; }
        public int AccountId { get => accountId; set => accountId = value; }
        public int BranchManagerId { get => branchManagerId; set => branchManagerId = value; }
        public double PrincipalAmount { get => principalAmount; set => principalAmount = value; }
        public string LoanType { get => loanType; set => loanType = value; }
        public double Interest { get => interest; set => interest = value; }
        public string SocialSecurity { get => socialSecurity; set => socialSecurity = value; }
        public int CreditScore { get => creditScore; set => creditScore = value; }
        public string CreationTime { get => creationTime; set => creationTime = value; }
    }
}
