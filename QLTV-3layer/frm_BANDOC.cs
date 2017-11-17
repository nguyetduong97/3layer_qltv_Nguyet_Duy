using BusinessLogic;
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
    public partial class frm_BANDOC : Form
    {
        bool cap_nhat = false;
        XL_BANDOC Bang_BANDOC;
        BindingManagerBase DS_BANDOC;
        public frm_BANDOC()
        {
            InitializeComponent();
        }

        private void frm_BANDOC_Load(object sender, EventArgs e)
        {
            Bang_BANDOC = new LOP.XL_BANDOC();
            Bang_BANDOC.Columns["MaThe"].ReadOnly = true;
            dgvDSBD.DataSource = Bang_BANDOC;
            txtMaThe.DataBindings.Add("text", Bang_BANDOC, "MaThe");
            txtTenBanDoc.DataBindings.Add("text", Bang_BANDOC, "TenBanDoc");
            txtDiaChi.DataBindings.Add("text", Bang_BANDOC, "DiaChi");
            txtDienThoai.DataBindings.Add("text", Bang_BANDOC, "SoDT");

            DS_BANDOC = this.BindingContext[Bang_BANDOC];
            DS_BANDOC.PositionChanged += DS_BANDOC_PositionChanged;

            An_hien_nut_lenh(false);
        }

        private void An_hien_nut_lenh(bool capnhat)
        {
            btnThem.Enabled = !capnhat;
            btnXoa.Enabled = !capnhat;
            btnSua.Enabled = !capnhat;
            btnGhi.Enabled = capnhat;
            btnKhongGhi.Enabled = capnhat;
        }

        private void DS_BANDOC_PositionChanged(object sender, EventArgs e)
        {
            if(cap_nhat== true)
            {
                btnKhongGhi_Click(sender, e);
            }
        }

        private void btnVeDau_Click(object sender, EventArgs e)
        {
            DS_BANDOC.Position = 0;
        }

        private void btnVecuoi_Click(object sender, EventArgs e)
        {
            DS_BANDOC.Position = DS_BANDOC.Count - 1;
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            DS_BANDOC.Position += 1;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DS_BANDOC.Position -= 1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            An_hien_nut_lenh(true);
            DS_BANDOC.AddNew();
            // phát sinh mã thẻ
            SqlConnection cnn = new SqlConnection(LOP.XL_BANG.Chuoi_lien_ket);
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "Phat_sinh_ma_the";
            cmd.Parameters.Add("MaThe", System.Data.SqlDbType.VarChar, 6);
            cmd.Parameters["MaThe"].Direction = System.Data.ParameterDirection.ReturnValue;


            DataRowView dr = (DataRowView)DS_BANDOC.Current;
            dr["MaThe"] = cmd.Parameters["MaThe"].Value.ToString();
            txtMaThe.Text = cmd.Parameters["MaThe"].Value.ToString();

            cnn.Close();
            cap_nhat = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DS_BANDOC.RemoveAt(DS_BANDOC.Position);
            if (!Bang_BANDOC.Ghi())
                MessageBox.Show("Xóa thất bại!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            An_hien_nut_lenh(true);
            cap_nhat = true;
        }

        private void btnKhongGhi_Click(object sender, EventArgs e)
        {
            DS_BANDOC.CancelCurrentEdit();
            Bang_BANDOC.RejectChanges();
            An_hien_nut_lenh(false);
            cap_nhat = false;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                DS_BANDOC.EndCurrentEdit();
                Bang_BANDOC.Ghi();
                An_hien_nut_lenh(false);
                cap_nhat = false;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvDSBD_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cap_nhat = true;
        }
    }
}
