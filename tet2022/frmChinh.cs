using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tet2022
{
    public partial class frmChinh : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmChinh()
        {
            InitializeComponent();
            Load += Form1_Load;
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(@"F:\Tet Nham Dan\tet2022\music\bgd.wav");
            sp.PlayLooping();
        }// cai nhac nen cho chuong trinh

        Timer t;
        readonly DateTime endTime = new DateTime(2022, 02, 01, 00, 00, 00); // end time chinh la dem Giao thua

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new Timer();
            t.Interval = 500;
            t.Tick += t_Tick;

            TimeSpan ts = endTime.Subtract(DateTime.Now);
            labelControl.Text = ts.ToString("dd' ngày 'hh' giờ 'mm' phút 'ss' giây'");

            t.Start();
        }// hien thi Dong ho Countdown

        private void t_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = endTime.Subtract(DateTime.Now);
            labelControl.Text = ts.ToString("dd' ngày 'hh' giờ 'mm' phút 'ss' giây'");
            if (ts.TotalSeconds <= 0)
                t.Stop();
        }// Bo Countdown Tet

        private void st_VanKhan_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_VanKhan"] == null)
            {
                frm_VanKhan vk = new frm_VanKhan();
                vk.Show();
            }
            else
                Application.OpenForms["frm_VanKhan"].Activate();
        }// neu form da mo roi thi thoi (han che toi da tinh trang mo form nhieu lan khi thuc hien lenh mo)

        private void frmChinh_Load(object sender, EventArgs e)
        {

        }

        private void st_ThiepchucTet_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_LoiChuc"] == null)
            {
                frm_LoiChuc lc = new frm_LoiChuc();
                lc.Show();
            }
            else
                Application.OpenForms["frm_LoiChuc"].Activate();
        }// neu form da mo roi thi thoi (han che toi da tinh trang mo form nhieu lan khi thuc hien lenh mo)

        private void st_PhongtucTet_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["frm_PhongTuc"] == null)
            {
                frm_PhongTuc lc = new frm_PhongTuc();
                lc.Show();
            }
            else
                Application.OpenForms["frm_PhongTuc"].Activate();
        }// neu form da mo roi thi thoi (han che toi da tinh trang mo form nhieu lan khi thuc hien lenh mo)
    }
}
