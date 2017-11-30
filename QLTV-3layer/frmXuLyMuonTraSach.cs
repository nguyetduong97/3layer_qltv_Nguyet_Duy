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

namespace QLTV_3layer
{
    public partial class frmXuLyMuonTraSach : Form
    {
        XL_BANDOC bang_BANDOC;
        XL_SACH bang_SACH;
        XL_MUONSACH bang_MUONSACH;
        BindingManagerBase DS_MUON_SACH;
        public frmXuLyMuonTraSach()
        {
            InitializeComponent();
        }

        private void An_hien_nut_lenh(bool capnhat)
        {
            btnGhi.Enabled = capnhat;
            btnkhongghi.Enabled = capnhat;
            btnMuonSach.Enabled = !capnhat;
            btnTraSach.Enabled = !capnhat;
            btnSua.Enabled = !capnhat;
        }

        private void frmXuLyMuonTraSach_Load(object sender, EventArgs e)
        {
            bang_MUONSACH = new XL_MUONSACH();
            bang_SACH = new XL_SACH();
            bang_BANDOC = new XL_BANDOC();

            cobMaThe.DataSource = bang_BANDOC;
            cobMaThe.DisplayMember = "MaThe";
            cobMaThe.ValueMember = "MaThe";
            txtTen.DataBindings.Add("text", bang_BANDOC, "TenBanDoc");
            txtSodt.DataBindings.Add("text", bang_BANDOC, "SoDT");
            txtDiaChi.DataBindings.Add("text", bang_BANDOC, "DiaChi");

            cobMaSach.DataSource = bang_SACH;
            cobMaSach.DisplayMember = "MaSach";
            cobMaSach.ValueMember = "MaSach";
            txtTenSach.DataBindings.Add("text", bang_SACH, "TuaDe");
            txtTacGia.DataBindings.Add("text", bang_SACH, "TacGia");

            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { bang_MUONSACH, bang_SACH });
            DataRelation qh = new DataRelation("FR_SACH_MUONSACH", bang_SACH.Columns["MaSach"], bang_MUONSACH.Columns["MaSach"]);
            ds.Relations.Add(qh);
            DataColumn cot_TuDe = new DataColumn("TuDe", Type.GetType("System.String"), "Parent(FR_SACH_MUONSACH).TuDe");
            DataColumn cot_TacGia = new DataColumn("TacGia", Type.GetType("System.String"), "Parent(FR_SACH_MUONSACH).TacGia");
            bang_MUONSACH.Columns.AddRange(new DataColumn[] { cot_TuDe, cot_TacGia });

            cobMaSach.DataBindings.Add("SelectedValue", bang_MUONSACH, "MaSach");
            dNgayMuon.DataBindings.Add("text", bang_MUONSACH, "NgayMuon");
            dNgayTra.DataBindings.Add("tetx", bang_MUONSACH, "NgayTra");

            dgvMuonSach.DataSource = bang_MUONSACH;
            DS_MUON_SACH = this.BindingContext[bang_MUONSACH];
            cobMaThe_SelectedIndexChang(sender, e);
        }

        private void cobMaThe_SelectedIndexChang(object sender, EventArgs e)
        {
            bang_MUONSACH.DefaultView.RowFilter = "MaThe ='" + cobMaThe.SelectedValue.ToString() + "' and NgayTra is Null";
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            An_hien_nut_lenh(true);
            DS_MUON_SACH.AddNew();
            DataRowView dr = (DataRowView)DS_MUON_SACH.Current;
            dr["MaThe"] = cobMaThe.SelectedValue;
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            An_hien_nut_lenh(true);
            dNgayMuon.Enabled =false;
            dNgayTra.Enabled = true;
        }
        private void btnkhongghi_Click_1(object sender, EventArgs e)
        {
            DS_MUON_SACH.CancelCurrentEdit();
            bang_MUONSACH.RejectChanges();
            An_hien_nut_lenh(false);
            dNgayTra.Enabled = false;
            dNgayMuon.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            An_hien_nut_lenh(true);
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            try
            {
                DS_MUON_SACH.EndCurrentEdit();
                bang_MUONSACH.Ghi();
                An_hien_nut_lenh(false);
                dNgayMuon.Enabled = true;
                dNgayTra.Enabled = false;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
