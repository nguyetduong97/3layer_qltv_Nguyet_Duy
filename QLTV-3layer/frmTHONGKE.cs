using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV_3layer
{
    public partial class frmTHONGKE : Form
    {
        public frmTHONGKE()
        {
            InitializeComponent();
        }

        private void frmTHONGKE_Load(object sender, EventArgs e)
        {
            rptMUONSACH rpt = new rptMUONSACH();
            DataSet ds = new DataSet();
            string query = " Select b.MaThe, b.TenBanDoc, s.MaSach, b.TuaDe, s.TacGia, NgayMuon, NgayTra " 
                            + " from (SACH s inner join BANDOC b on m.MaThe = b.MaThe " 
                            + " where NgayTra is Null ";
            SqlDataAdapter da = new SqlDataAdapter(query, XL_BANG.Chuoi_lien_ket);
            da.Fill(ds);
            rpt.SetDataSource(ds.Tables[0]);
            cRPTHONGKE.ReportSource = rpt;
        }

        private void cRPTHONGKE_Load(object sender, EventArgs e)
        {

        }
    }
}
