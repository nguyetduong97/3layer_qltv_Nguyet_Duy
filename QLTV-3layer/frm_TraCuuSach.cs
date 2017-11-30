using BusinessLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV_3layer
{
    public partial class frm_TraCuuSach : Form
    {
        XL_SACH Bang_SACH;
        XL_NHAXUATBAN Bang_NHAXUATBAN;
        XL_THELOAI Bang_THELOAI;
        public frm_TraCuuSach()
        {
            InitializeComponent();
        }

        private void frm_TraCuuSach_Load(object sender, EventArgs e)
        {

            Bang_SACH = new XL_SACH();
            Bang_THELOAI = new XL_THELOAI();
            Bang_NHAXUATBAN = new XL_NHAXUATBAN();
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { Bang_SACH, Bang_NHAXUATBAN, Bang_THELOAI });
            DataRelation qh_NHAXUABAN_SACH = new DataRelation("FK_NHAXUATBAN_SACH", Bang_NHAXUATBAN.Columns["MaNXB"], Bang_SACH.Columns["MaNXB"]);
            DataRelation qh_THELOAI_SACH = new DataRelation("FK_THELOAI_SACH", Bang_THELOAI.Columns["MaTL"], Bang_SACH.Columns["MaTL"]);
            ds.Relations.AddRange(new DataRelation[] { qh_NHAXUABAN_SACH, qh_THELOAI_SACH });
            DataColumn cot_TenNXB = new DataColumn("TenNXB", Type.GetType("System.String"), "Parent(FK_NHAXUATBAN_SACH).TenNXB");
            DataColumn cot_TenTL = new DataColumn("TenTL", Type.GetType("System.String"), "Parent(FK_THELOAI_SACH).TenTL");
            Bang_SACH.Columns.AddRange(new DataColumn[] { cot_TenNXB, cot_TenTL });
            cobNSX.DataSource = Bang_NHAXUATBAN;
            cobNSX.DisplayMember = "TenNXB";
            cobNSX.ValueMember = "MaTL";

            cobTheLoai.DataSource = Bang_THELOAI;
            cobTheLoai.DisplayMember = "TenTL";
            cobTheLoai.ValueMember = "MaTL";

            dgvTraCuu.DataSource = Bang_SACH;
            Nhap_moi();
        }

        private void Nhap_moi()
        {
            throw new NotImplementedException();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string chuoi_DK = "";
            ArrayList mang_DK = new ArrayList();
            if (txtMaSach.Text != "")
                mang_DK.Add("MaSach Like '*" + txtMaSach.Text + " *'");
            if(txtTenSach.Text != "")
                mang_DK.Add("TuaDe Like '*" + txtTenSach.Text + " *'");
            if (txtTacGia.Text != "")
                mang_DK.Add("TacGia Like '*" + txtTacGia.Text + " *'");
            if (txtSoLuong.Text != "")
                mang_DK.Add("SoLuong Like '*" + txtSoLuong.Text + " *'");
            if (cobNSX.Text != "")
                mang_DK.Add("MaNSX Like '*" +cobNSX.SelectedValue + " *'");
            if (cobTheLoai.Text != "")
                mang_DK.Add("TuaDe Like '*" + cobTheLoai.SelectedValue + " *'");
            if(mang_DK.Count>0)
            {
                for (int i = 0; i < mang_DK.Count; i++)
                    if (i == 0) chuoi_DK = mang_DK[i].ToString();
                    else chuoi_DK += " AND " + mang_DK[i];
            }
            Bang_SACH.Loc_du_lieu(chuoi_DK);
        }
    }
}
