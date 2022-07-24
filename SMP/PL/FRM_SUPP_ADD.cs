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
    public partial class FRM_SUPP_ADD: Form
    {
        //init    ل قواعد البيانات  انشلايز
       // قاعد البيانات بنممرها من خلال الجدول عندنا زوز حقول اسم وصوره  
        DB_SMPEntities db = new DB_SMPEntities();
        TB_Supp tb_supp = new TB_Supp();
        Beassens_Lare.Methods methods = new Beassens_Lare.Methods();

        

        public int id;

        public FRM_SUPP_ADD()
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
                dialog.txt_capation.Text = "اسم المورد مطلوب";
                dialog.Show();
            }
            else
            {
                //check if add or edit  عملية الاضافة 
                if(id==0)
                {
                    //add  ma متع MemoryString  بعدها تستقبل نوع الملف لتبيه
                    pic_cover.Image.Save(methods.ma, System.Drawing.Imaging.ImageFormat.Png);
                    
                    //قمنا بارسال البيانات بشكل مباشر للكلاس ملتي 
                    tb_supp.Supp_Name = edit_name.Text;
                    tb_supp.Supp_Phone = edt_phone.Text;
                    tb_supp.Supp_Email = edt_email.Text;
                    tb_supp.Supp_Image = methods.convert_byte();//يستقبل الصورة ثم يتم تحويلها

                    db.TB_Supp.Add(tb_supp);// قمنا باعملية الاضافة في جدول قاعد البيانات
                    db.SaveChanges();//حفضها في قاعد البيانات

                    toast.txt_capation.Text = "تم اضافة مورد جديد";
                    toast.Show();// ثم عرضنه توست رسالة لنوضح للمستخدم تم الاضافة

                  //  db = new DB_SMPEntities();  //لثحديث البيانات بشكل تلقلئي 
                  //  frm_cat.gridControl1.DataSource = db.TB_CAT.ToList();

                    this.Close();// غرض منها بعد متم عملية اضافة تتسكر الفورم
                }
                else
                {
                    //Edit

                    //add  ma متع MemoryString  بعدها تستقبل نوع الملف لتبيه
                    //add  ma متع MemoryString  بعدها تستقبل نوع الملف لتبيه
                    pic_cover.Image.Save(methods.ma, System.Drawing.Imaging.ImageFormat.Png);
                    tb_supp.ID = id;//
                    //قمنا بارسال البيانات بشكل مباشر للكلاس ملتي 
                    tb_supp.Supp_Name = edit_name.Text;
                    tb_supp.Supp_Phone = edt_phone.Text;
                    tb_supp.Supp_Email = edt_email.Text;
                    tb_supp.Supp_Image = methods.convert_byte();//يستقبل الصورة ثم يتم تحويلها

                    db.Entry(tb_supp).State = System.Data.Entity.EntityState.Modified;// قمنا باعملية الاضافة في جدول قاعد البيانات
                    db.SaveChanges();//حفضها في قاعد البيانات

                    toast.txt_capation.Text = "تم تعديل مورد ";
                    toast.Show();// ثم عرضنه توست رسالة لنوضح للمستخدم تم الاضافة

                    //  db = new DB_SMPEntities();  //لثحديث البيانات بشكل تلقلئي 
                    //  frm_cat.gridControl1.DataSource = db.TB_CAT.ToList();

                    this.Close();// غرض منها بعد متم عملية اضافة تتسكر الفورم
                }
            }
        }

        private void btn_colse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
