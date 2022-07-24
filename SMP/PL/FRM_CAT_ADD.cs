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
    public partial class FRM_CAT_ADD : Form
    {
        //init    ل قواعد البيانات  انشلايز
       // قاعد البيانات بنممرها من خلال الجدول عندنا زوز حقول اسم وصوره  
        DB_SMPEntities db = new DB_SMPEntities();
        TB_CAT tb_cat = new TB_CAT();
        Beassens_Lare.Methods methods = new Beassens_Lare.Methods();

        Present_Lare.FRM_CAT frm_cat = new Present_Lare.FRM_CAT();


        
       

        public int id;

        public FRM_CAT_ADD()
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
                    //add  ma متع MemoryString  بعدها تستقبل نوع الملف لتبيه
                    pic_cover.Image.Save(methods.ma, System.Drawing.Imaging.ImageFormat.Jpeg);
                    
                    //قمنا بارسال البيانات بشكل مباشر للكلاس ملتي 
                    tb_cat.CAT_Name = edit_name.Text;
                    tb_cat.CAT_Cover = methods.convert_byte();

                    db.TB_CAT.Add(tb_cat);//قمنا باعملية الاضافة
                    db.SaveChanges();//حفضها في قاعد البيانات

                    toast.txt_capation.Text = "تم اضافة صنف جديد";
                    toast.Show();// ثم عرضنه توست رسالة لنوضح للمستخدم تم الاضافة

                    db = new DB_SMPEntities();  //لثحديث البيانات بشكل تلقلئي 
                    frm_cat.gridControl1.DataSource = db.TB_CAT.ToList();

                    this.Close();// غرض منها بعد متم عملية اضافة تتسكر الفورم
                }
                else
                {
                    //Edit
                   
                    //add  ma متع MemoryString  بعدها تستقبل نوع الملف لتبيه
                    pic_cover.Image.Save(methods.ma, System.Drawing.Imaging.ImageFormat.Jpeg);

                    //قمنا بارسال البيانات بشكل مباشر للكلاس ملتي 
                    tb_cat.CAT_Name = edit_name.Text;
                    tb_cat.ID = id;// 

                    tb_cat.CAT_Cover = methods.convert_byte();

                    db.Entry(tb_cat).State = System.Data.Entity.EntityState.Modified;//قمنا باعملية تعديل
                    db.SaveChanges();//حفضها في قاعد البيانات

                    toast.txt_capation.Text = "تم تعديل صنف جديد";
                    toast.Show();// ثم عرضنه توست رسالة لنوضح للمستخدم تم الاضافة

                    db = new DB_SMPEntities();  //لثحديث البيانات بشكل تلقلئي 
                    frm_cat.gridControl1.DataSource = db.TB_CAT.ToList();

                    this.Close();
                }
            }
        }

        private void btn_colse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
