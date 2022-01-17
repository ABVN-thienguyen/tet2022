using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace tet2022
{
    public partial class frm_PhongTuc : DevExpress.XtraEditors.XtraForm
    {
        public frm_PhongTuc()
        {
            InitializeComponent();
        }

        DatabaseInteraction db = new DatabaseInteraction();

        private void frm_PhongTuc_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.HienThiDuLieu("Select TENPT, MOTA, ANH from PHONGTUC");
        }// load data

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_TieuDe.Text = dataGridView1.CurrentRow.Cells["TENPT"].Value.ToString();
            lbl_NoiDung.Text = dataGridView1.CurrentRow.Cells["MOTA"].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells["ANH"].Value.ToString();
        } // hien thi du lieu tu DataGridView

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select TENPT, MOTA, ANH from PHONGTUC where TENPT like '%" + txt_Search.Text + "%'";
            dataGridView1.DataSource = db.HienThiDuLieu(sql);
        }// tim kiem real-time (nhap xong tu dong hien thi ket qua)
    }
}