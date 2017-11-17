using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
   public class XL_LOAITK : XL_BANG
    {
        public XL_LOAITK(): base("LOAITK") { }
        public XL_LOAITK(string pChuoi_SQL) : base("LOAITK", pChuoi_SQL) { }

    }
}
