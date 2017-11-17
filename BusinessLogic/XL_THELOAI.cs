using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
   public class XL_THELOAI: XL_BANG
    {
        public XL_THELOAI(): base("THELOAI") { }
        public XL_THELOAI(string pChuoi_SQL) : base("THELOAI", pChuoi_SQL) { }

    }
}
