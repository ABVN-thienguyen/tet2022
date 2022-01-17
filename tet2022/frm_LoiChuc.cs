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
    public partial class frm_LoiChuc : DevExpress.XtraEditors.XtraForm
    {
        public frm_LoiChuc()
        {
            InitializeComponent();
        }
        DatabaseInteraction db = new DatabaseInteraction();
        private void frm_LoiChuc_Load(object sender, EventArgs e)
        {
            // Hien thi du lieu vao Listbox
            listBox1.DataSource = db.HienThiDuLieu("Select * from LOICHUC");
            // Gan tri
            listBox1.ValueMember = "NOIDUNG";
            listBox1.DisplayMember = "MALC";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_LoiChuc.Text = listBox1.SelectedValue.ToString(); // hien thi loi chuc tu listbox
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_LoiChuc.Text); // gan loi chuc vao clipboard
        }
    }
}