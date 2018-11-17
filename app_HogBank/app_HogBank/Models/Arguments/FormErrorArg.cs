using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Models.Arguments
{
    class FormErrorArg : FormInfoArg
    {
        public Exception exception;

        public FormErrorArg(string msg, Exception e) : base(msg)
        {
            message = msg;
            exception = e;
        }
    }
}
