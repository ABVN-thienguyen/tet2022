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
using System.Data.SqlClient;

namespace tet2022
{
    public partial class frm_VanKhan : DevExpress.XtraEditors.XtraForm
    {
        public frm_VanKhan()
        {
            InitializeComponent();
        }

        DatabaseInteraction db = new DatabaseInteraction();


        private void frm_VanKhan_Load(object sender, EventArgs e)
        {
            // load data
            listBox1.DataSource = db.HienThiDuLieu("Select * from VANKHAN");
            // gan tri
            listBox1.ValueMember = "NOIDUNG";
            listBox1.DisplayMember = "TENVK";
            // nhet vao Panel
            panel1.Controls.Add(lbl_NoiDung);
            panel1.Controls.Add(lbl_Ten);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {                       
            if (listBox1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listBox1.SelectedItems.Count; i++)
                {
                    lbl_Ten.Text = listBox1.GetItemText(listBox1.SelectedItems[i]);
                }// hien thi ten van khan
                lbl_NoiDung.Text = listBox1.SelectedValue.ToString(); // hien thi noi dung van khan
            } // hien thi data, cach nay ngan ngua loi kg hien duoc du lieu
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select * from VANKHAN where TENVK like '%" + txt_Search.Text + "%'";
            listBox1.DataSource = db.HienThiDuLieu(sql);
        }// real-time searching

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_NoiDung.Text);
        }// gan noi dung van khan vao clipboard

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1; // tai lieu hien thi trong print preview la van khan
            printPreviewDialog1.ShowDialog(); // hien thi print preview
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(lbl_Ten.Text, new Font("Times New Roman", 18, FontStyle.Bold), Brushes.Black, new PointF(250, 80));
            e.Graphics.DrawString(lbl_NoiDung.Text, new Font("Times New Roman", 12), Brushes.Black, new PointF(50, 150));         
        }// ghi van khan
    }
}