using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
   public class XL_TAIKHOAN: XL_BANG
    {
        public XL_TAIKHOAN(): base("TAIKHOAN") { }
        public XL_TAIKHOAN(string pChuoi_SQL): base("TAIKHOAN", pChuoi_SQL) { }
    }
}
