using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic
{
   public class XL_NHANVIEN: XL_BANG
    {
        public XL_NHANVIEN(): base("NHANVIEN") { }
        public XL_NHANVIEN(string pChuoi_SQL) : base("NHANVIEN", pChuoi_SQL) { }
    }
}
