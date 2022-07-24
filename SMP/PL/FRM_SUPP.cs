using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using SMP.EPL;

namespace SMP.Present_Lare
{
    public partial class FRM_SUPP: Form
    {     
        // هدي انا كتبتها درنا انشلايز لقاعد البيانات
        DB_SMPEntities db = new DB_SMPEntities();

        TB_Supp tb_supp = new TB_Supp();//

        Beassens_Lare.Methods methods = new Beassens_Lare.Methods();
         
        int id;
        public FRM_SUPP()
        {
            InitializeComponent();
           
            SMP.DB_SMPEntities dbContext = new SMP.DB_SMPEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.TB_Supp.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.TB_Supp.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void FRM_CAT_Load(object sender, EventArgs e)
        {

        }
        //ADD
        private void btn_add_Click(object sender, EventArgs e)
        {
            PL.FRM_SUPP_ADD frm_add = new PL.FRM_SUPP_ADD();
            frm_add.id = 0;
            frm_add.btn_add.Text = "اضافة";
            frm_add.Show();
        }

        //update 
        private void simpleButton4_Click(object sender, EventArgs e)
            //btn_update_click الدلة هدي اسمها 
        {
            // في كل هملية ثحديث بندبرو انشلايز لقاعد البيانات اضافة وحدف وتعديل 

            // db = new DB_SMPEntities();
            // gridControl1.DataSource = db.TB_CAT.ToList();

            Update_data();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            Toast toast = new Toast();
            Diailog dialog = new Diailog();
            id =Convert.ToInt32( tileView1.GetFocusedRowCellValue("ID"));
         if(id > 0)
            { 
         try
         {
            var rs = MessageBox.Show("عملية حدف", "هل انت متأكد من عملية الحدف", MessageBoxButtons.YesNo);
           

            if(rs==DialogResult.Yes)
            {
                    tb_supp = db.TB_Supp.Where(x => x.ID == id).FirstOrDefault();
                    db.Entry(tb_supp).State = EntityState.Deleted;
                    db.SaveChanges();
                    toast.txt_capation.Text = "تم حذف مورد";
                    toast.Show();
                    Update_data();
            }
         }
            catch
            {
                
            }
           
           }
         else
            {
                dialog.txt_capation.Text = "لا يوجد مورد لحدفة";
                dialog.Width = this.Width;
                dialog.Show();

            }
        }

        private void Update_data()
        {
            db = new DB_SMPEntities();
             gridControl1.DataSource = db.TB_Supp.ToList();
        }

        //Edit
        //قال عملية تعديل تشبه الاضافة
        private void btn_edit_Click(object sender, EventArgs e)
        {
            PL.FRM_SUPP_ADD frm_add = new PL.FRM_SUPP_ADD();

            id = Convert.ToInt32(tileView1.GetFocusedRowCellValue("ID"));//
            tb_supp = db.TB_Supp.Where(x => x.ID == id).FirstOrDefault();//
            frm_add.edit_name.Text = tb_supp.Supp_Name.ToString();
            frm_add.edt_phone.Text = tb_supp.Supp_Phone.ToString();
            frm_add.edt_email.Text = tb_supp.Supp_Email.ToString();

            methods.by = tb_supp.Supp_Image;
            frm_add.pic_cover.Image = Image.FromStream(methods.convert_image());

            frm_add.id = id;
            frm_add.btn_add.Text = "تعديل";
            frm_add.Show();
        }

        private void btn_serach_Click(object sender, EventArgs e)
        {
            var _search = edit_serch.Text;
            gridControl1.DataSource=db.TB_Supp.Where(x=>x.Supp_Name.Contains(_search) || x.Supp_Phone.Contains(_search) || x.Supp_Email.Contains(_search)).ToList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
