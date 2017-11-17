using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class XL_MUONSACH : XL_BANG
    {
        public XL_MUONSACH(): base("MUONSACH") { }
        public XL_MUONSACH(string pChuoi_SQL) : base("MUONSACH", pChuoi_SQL) { }

    }
}
