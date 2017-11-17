using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
   public class XL_SACH : XL_BANG
    {
        public XL_SACH(): base("SACH") { }
        public XL_SACH(string pChuoi_SQL) : base("SACH", pChuoi_SQL) { }
    }
}
