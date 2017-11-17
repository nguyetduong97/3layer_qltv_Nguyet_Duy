using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
namespace BusinessLogic 
{
   public class XL_BANDOC: XL_BANG
    {
        public XL_BANDOC(): base("BANDOC") { }
        public XL_BANDOC(string pChuoi_SQL) : base("BANDOC", pChuoi_SQL) { }
    }
}
