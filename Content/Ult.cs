using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public static class Ult
    {
        public static string GetOgr(string org, string Loc)
        {
            return org + ((Loc == null) ? "" : ", " + Loc); 
        }
    }
}
