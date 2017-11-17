using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataAccess
{
    public class XL_BANG : DataTable
    {
        #region biến cục bộ
        public static String Chuoi_lien_ket;
        private SqlDataAdapter mBo_doc_ghi = new SqlDataAdapter();
        private SqlConnection mKet_noi;
        private String mChuoi_SQL;
        private String mTen_bang;
        private string v;
        #endregion
        #region Các thuộc tính
        public String Chuoi_SQL
        {
            get {
                return Chuoi_SQL;
            }
            set { mChuoi_SQL= value; }
        }
        public String Ten_bang
        {
            get { return mTen_bang; }
            set { mTen_bang = value; }
        }
        public int So_dong
        {
            get { return this.DefaultView.Count; }
        }

        #endregion
        #region Cac phuong thc khoi tao
        public XL_BANG() : base() { }
        //tao moi bang voi ten pTen_bang
        public XL_BANG(String pTen_bang, String pChuoi_SQL)
        {
            mTen_bang = pTen_bang;
            mChuoi_SQL = pChuoi_SQL;
            Doc_bang();
        }

        public XL_BANG(string v)
        {
            this.v = v;
        }
        #endregion
        #region cac phuong thuc xu ly: doc, ghi, loc du lieu
        private void Doc_bang()
        {
            if(mChuoi_SQL == null)
            {
                mChuoi_SQL = "SELECT * FROM " + mTen_bang;
            }
            if (mKet_noi == null)
                mKet_noi = new SqlConnection(Chuoi_lien_ket);
            try
            {
                mBo_doc_ghi = new SqlDataAdapter(mChuoi_SQL, mKet_noi);
                mBo_doc_ghi.FillSchema(this, SchemaType.Mapped);
                mBo_doc_ghi.Fill(this);
                mBo_doc_ghi.RowUpdated += new SqlRowUpdatedEventHandler(mBo_doc_ghi_RowUpdated);
                SqlCommandBuilder Bo_phat_sinh = new SqlCommandBuilder(mBo_doc_ghi);
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
        public Boolean Ghi()
        {
            Boolean ket_qua = true;
            try
            {
                mBo_doc_ghi.Update(this);
                this.AcceptChanges();
            }
            catch(SqlException ex)
            {
                this.RejectChanges();
                ket_qua = false;
            }
            return ket_qua;
        }
        //Lọc dữ liệu
        public void Loc_du_lieu(String pDieu_kien)
        {
            try
            {
                this.DefaultView.RowFilter = pDieu_kien;
            }catch(SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void mBo_doc_ghi_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if(this.PrimaryKey[0].AutoIncrement)
            {
                if((e.Status == UpdateStatus.Continue) && (e.StatementType ==  StatementType.Insert))
                {
                    SqlCommand cmd = new SqlCommand("Select @@IDENTITY ", mKet_noi);
                    e.Row.ItemArray[0] = cmd.ExecuteScalar();
                    e.Row.AcceptChanges();
                }
            }
        }
        #endregion

    }
}
