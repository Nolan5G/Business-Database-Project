using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Models.Arguments
{
    class FormInfoArg : EventArgs
    {
        public string message;

        public FormInfoArg(string message)
        {
            this.message = message;
        }
    }
}
