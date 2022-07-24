using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMP
{
    


    public partial class Main : Form
    {
        Present_Lare.FRM_HOME frm_home = new Present_Lare.FRM_HOME();
        Present_Lare.FRM_CAT frm_cat = new Present_Lare.FRM_CAT();
        Present_Lare.FRM_SUPP frm_supp = new Present_Lare.FRM_SUPP();
        Present_Lare.FRM_Pur frm_pur = new Present_Lare.FRM_Pur();
        Present_Lare.FRM_CUS frm_cus = new Present_Lare.FRM_CUS();


        // هدي انا كتبتها درنا انشلايز لقاعد البيانات
        DB_SMPEntities db = new DB_SMPEntities();

        public Main()
        {
            InitializeComponent();
        }
        //close app
        private void btn_colse_Click(object sender, EventArgs e)
        {
             Environment.Exit(0);
          //  this.Close();
        }
        //min app
        private void btn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        //mix app
        private void btn_mix_Click(object sender, EventArgs e)
        {
            if(WindowState==FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }
      
        //btn_collopase
        private void btn_collopase_Click(object sender, EventArgs e)
        {
            if(pan_navpar.Width== 208)
            {
                pan_navpar.Width = 50;
                pn_titel_navepare.Visible = false;
                pn_hader_navebaer.Height = 200;


            }
            else
            {
                pan_navpar.Width = 208;
                pn_titel_navepare.Visible = true;
                pn_hader_navebaer.Height = 246;

            }
        }
        //Load home page
        private void btn_home_Click(object sender, EventArgs e)
        {// صغحة الرائسية
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_home.pn_Home);
              
        }

        private void Main_Load(object sender, EventArgs e)
        {// صغحة الرائسية
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_home.pn_Home);
        }

        //Load cat
        private void btn_cat_Click(object sender, EventArgs e)
        {//الاصناف
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_cat.pn_cat);
             
            db = new DB_SMPEntities();//لتحديث البيانات اثناء عملية النقر
            frm_cat.gridControl1.DataSource = db.TB_CAT.ToList();

        }
        //LOAD SUPP
        private void btn_supp_Click(object sender, EventArgs e)
        {//الموردين
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_supp.pn_cat);

            db = new DB_SMPEntities();//لتحديث البيانات اثناء عملية النقر
            
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {//مشتريات
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_pur.pn_cat);

            db = new DB_SMPEntities();//لتحديث البيانات اثناء عملية النقر
            
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            //العملاء
            pn_cont.Controls.Clear();
            pn_cont.Controls.Add(frm_cus.pn_cat);

            db = new DB_SMPEntities();//لتحديث البيانات اثناء عملية النقر

        }
    }
}
