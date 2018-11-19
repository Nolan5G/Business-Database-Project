using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Resources
{
    class GlobalVariables
    {
        public const bool DEBUG = true;

        private static readonly Lazy<GlobalVariables> lazy = new Lazy<GlobalVariables>(() => new GlobalVariables() { });

        public static GlobalVariables Instance
        {
            get { return lazy.Value; }
        }
    }
}
