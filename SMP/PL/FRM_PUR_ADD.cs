using SMP.EPL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMP.PL
{
    public partial class FRM_PUR_ADD: Form
    {
        //init    ل قواعد البيانات  انشلايز
       // قاعد البيانات بنممرها من خلال الجدول عندنا زوز حقول اسم وصوره  
        DB_SMPEntities db = new DB_SMPEntities();
        TB_Pur tb_pur = new TB_Pur();
        Beassens_Lare.Methods methods = new Beassens_Lare.Methods();
        double buy, sell, qt, tbuy, tsell, trev;
        

        public int id;

        public FRM_PUR_ADD()
        {
            InitializeComponent();
        }
        
        
        //Add or Edit
        private void btn_add_Click(object sender, EventArgs e)
        {  
            // تصميم ال ديلوك مني انا متع رسالة 
            Toast toast = new Toast();
            Diailog dialog = new Diailog();

            //check if  add or edit
             
            if (edit_name.Text=="")
            {
                dialog.Width = this.Width;
                dialog.txt_capation.Text = "اسم الصنف مطلوب";
                dialog.Show();
            }
            else
            {
                //check if add or edit  عملية الاضافة 
                if(id==0)
                {
                    tb_pur.Pur_Name = edit_name.Text;
                    tb_pur.Pur_Type = edt_type.Text;
                    tb_pur.Pur_Cat = edt_cat.Text;
                    tb_pur.Pur_Supp = edt_supp.Text;
                    tb_pur.Pur_Det = edt_det.Text;
                    tb_pur.Pur_Buy = Convert.ToDouble(edt_buy.Text);
                    tb_pur.Pur_Sell = Convert.ToDouble(edt_sell.Text);
                    tb_pur.Pur_Qt = Convert.ToDouble(edt_qt.Text);
                    tb_pur.Pur_Tbuy = Convert.ToDouble(edt_tbuy.Text);
                    tb_pur.Pur_Tsell = Convert.ToDouble(edt_tsell.Text);
                    tb_pur.Pur_TRve = Convert.ToDouble(edt_trve.Text);
                    db.TB_Pur.Add(tb_pur);
                    db.SaveChanges();
                    toast.txt_capation.Text = "تم اجراء عملية الشراء";
                    toast.Show();
              
                    this.Close();// غرض منها بعد متم عملية اضافة تتسكر الفورم
                }
                else
                {
                    //Edit

                    
                    tb_pur.ID = id;//
                    tb_pur.Pur_Name = edit_name.Text;
                    tb_pur.Pur_Type = edt_type.Text;
                    tb_pur.Pur_Cat = edt_cat.Text;
                    tb_pur.Pur_Supp = edt_supp.Text;
                    tb_pur.Pur_Det = edt_det.Text;
                    tb_pur.Pur_Buy = Convert.ToDouble(edt_buy.Text);
                    tb_pur.Pur_Sell = Convert.ToDouble(edt_sell.Text);
                    tb_pur.Pur_Qt = Convert.ToDouble(edt_qt.Text);
                    tb_pur.Pur_Tbuy = Convert.ToDouble(edt_tbuy.Text);
                    tb_pur.Pur_Tsell = Convert.ToDouble(edt_tsell.Text);
                    tb_pur.Pur_TRve = Convert.ToDouble(edt_trve.Text);


                    db.Entry(tb_pur).State = System.Data.Entity.EntityState.Modified;// قمنا باعملية الاضافة في جدول قاعد البيانات
                    db.SaveChanges();//حفضها في قاعد البيانات

                    toast.txt_capation.Text = "تم تعديل عملية الشراء ";
                    toast.Show();// ثم عرضنه توست رسالة لنوضح للمستخدم تم الاضافة
                    this.Close();// غرض منها بعد متم عملية اضافة تتسكر الفورم

                    //  db = new DB_SMPEntities();  //لثحديث البيانات بشكل تلقلئي 
                    //  frm_cat.gridControl1.DataSource = db.TB_CAT.ToList();

                }
            }
        }

        private void btn_colse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic_cover_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void edt_buy_TextChanged(object sender, EventArgs e)
        {
            pro_cal(); 
        }

        private void edt_sell_TextChanged(object sender, EventArgs e)
        {
            pro_cal();
        }

        private void edt_qt_EditValueChanged(object sender, EventArgs e)
        {
            pro_cal();
        }

        private void edit_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FRM_PUR_ADD_Activated(object sender, EventArgs e)
        {
            //هدي متع comboboks
            edt_cat.DataSource = db.TB_CAT.Select(x => x.CAT_Name).ToList();
            edt_supp.DataSource = db.TB_Supp.Select(x => x.Supp_Name).ToList();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PL.FRM_CAT_ADD frm_add = new PL.FRM_CAT_ADD();
            frm_add.id = 0;
            frm_add.btn_add.Text = "اضافة";
            frm_add.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PL.FRM_SUPP_ADD frm_add = new PL.FRM_SUPP_ADD();
            frm_add.id = 0;
            frm_add.btn_add.Text = "اضافة";
            frm_add.Show();
        }

        private void pro_cal() //هدي لازم تشرح عليها للفهم
        {
            sell = Convert.ToDouble(edt_sell.Text);
            buy = Convert.ToDouble(edt_buy.Text);
            qt = Convert.ToDouble(edt_qt.Value);
            //عماليات الحسابية
            tsell = sell * qt;//كمية في المبيعات
            tbuy = buy * qt;//كمية في مشتريات
            trev = tsell - tbuy;//الارباح=مجموع مشتربات-المبيعات
            //اسناد
            edt_tsell.Text = tsell.ToString();
            edt_tbuy.Text = tbuy.ToString();
            edt_trve.Text = trev.ToString();



        }
    }
}
