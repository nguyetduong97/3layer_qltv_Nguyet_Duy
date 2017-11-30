using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DataAccess;

namespace QLTV_3layer
{
    public partial class frm_Sach : Form
    {
        XL_SACH Bang_SACH;
        XL_NHAXUATBAN Bang_NHAXUATBAN;
        XL_THELOAI Bang_THELOAI;
        BindingManagerBase DS_SACH;
        public frm_Sach()
        {
            InitializeComponent();
        }

        private void frm_Sach_Load(object sender, EventArgs e)
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
            cobNSX.ValueMember = "MaNXB";

            cobTheLoai.DataSource = Bang_THELOAI;
            cobTheLoai.DisplayMember = "TenTL";
            cobTheLoai.ValueMember = "MaTL";

            dgvSach.DataSource = Bang_SACH;

            txtMaSach.DataBindings.Add("text", Bang_SACH, "MaSach");
            txtTenSach.DataBindings.Add("text", Bang_SACH, "TuaDe");
            txtTacGia.DataBindings.Add("text", Bang_SACH, "TacGia");
            txtSoLuong.DataBindings.Add("text", Bang_SACH, "SoLuong");
            dtNgayNhap.DataBindings.Add("text", Bang_SACH, "NgayNhap");
            cobNSX.DataBindings.Add("SelectedValue", Bang_SACH, "MaNSX");
            cobTheLoai.DataBindings.Add("SelectedValue", Bang_SACH, "MaTL");

            //
            DS_SACH = this.BindingContext[Bang_SACH];
            An_hien_nut_lenh(false);


        }

        private void An_hien_nut_lenh(bool capnhat)
        {
            btnNhap.Enabled = !capnhat;
            btnHuy.Enabled = !capnhat;
            btnSua.Enabled = !capnhat;
            btnKhongGhi.Enabled = capnhat;
            btnGhi.Enabled = capnhat;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            An_hien_nut_lenh(true);
            DS_SACH.AddNew();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DS_SACH.RemoveAt(DS_SACH.Position);
            if(!Bang_SACH.Ghi())
            {
                MessageBox.Show("Xóa Thất Bại!!!");
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            //phát sinh mã sách
            SqlConnection cnn = new SqlConnection(XL_BANG.Chuoi_lien_ket);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Phat_Sinh_Ma_Sach";
            cmd.Parameters.Add("MaTL", System.Data.SqlDbType.VarChar, 2);
            cmd.Parameters["MaTL"].Value = cobTheLoai.SelectedValue;
            cmd.Parameters.Add("MaSach", System.Data.SqlDbType.VarChar, 6);
            cmd.Parameters["MaSach"].Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteScalar();

            //
            DataRowView dr = (DataRowView)DS_SACH.Current;
            dr["MaSach"] = cmd.Parameters["MaSach"].Value.ToString();
            txtMaSach.Text = cmd.Parameters["MaSach"].Value.ToString();
            cnn.Close();
            //
            try
            {
                DS_SACH.EndCurrentEdit();
                Bang_SACH.Ghi();
                An_hien_nut_lenh(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            An_hien_nut_lenh(true);
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            DS_SACH.CancelCurrentEdit();
            Bang_SACH.RejectChanges();
            An_hien_nut_lenh(false);
        }

        private void dgvSach_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            dgvSach.Rows[e.Row.Index].Cells["STT"].Value = e.Row.Index + 1;
        }

        private void dgvSach_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvSach.Rows)
            {
                r.Cells["STT"].Value = r.Index + 1;
            }
        }
    }
}
