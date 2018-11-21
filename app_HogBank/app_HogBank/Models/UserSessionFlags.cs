using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Models
{
    class UserSessionFlags
    {
        public bool isEmployee;
        public bool isTeller;
        public bool isBranchManager;

        public UserSessionFlags()
        {
            isEmployee = false;
            isTeller = false;
            isBranchManager = false;
        }

        public UserSessionFlags(bool isEmployee, bool isTeller, bool isBranchManager)
        {
            this.isEmployee = isEmployee;
            this.isTeller = isTeller;
            this.isBranchManager = isBranchManager;
        }
    }
}
