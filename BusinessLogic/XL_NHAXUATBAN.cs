using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
   public class XL_NHAXUATBAN: XL_BANG
    {
        public XL_NHAXUATBAN(): base("NHAXUATBAN") { }
        public XL_NHAXUATBAN(string pChuoi_SQL): base("NHAXUATBAN", pChuoi_SQL) { }
    }
}
