using BusinessLogic;
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
    public partial class frm_DangNhap : Form
    {
        public Form1 parentForm;
        public Form1 setParentForm
        {
            set { parentForm = value; }
        }

        public frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            XL_BANG.Chuoi_lien_ket = "Data Source=.\\SQLEXPRESS;Initial Catalog=QLTHUVIEN;Integrated Security=True";
            try
            {
                XL_TAIKHOAN tk = new XL_TAIKHOAN("select * from TAIKHOAN where TenTK = '" + txtUserName.Text + "' and MatKhau = '" + txtPassword.Text + "'");
                if(tk.Rows.Count>0)
                {
                    parentForm.login(txtUserName.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng Nhập sai UserName và Password");
                }
            }catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frm_DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
