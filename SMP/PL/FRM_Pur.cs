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
    public partial class FRM_Pur: Form
    {     
        // هدي انا كتبتها درنا انشلايز لقاعد البيانات
        DB_SMPEntities db = new DB_SMPEntities();

        TB_Pur tb_pur = new TB_Pur();// اول وحد بتعدلها

        Beassens_Lare.Methods methods = new Beassens_Lare.Methods();
         
        int id;
        public FRM_Pur()
        {
            InitializeComponent();

           
            SMP.DB_SMPEntities dbContext = new SMP.DB_SMPEntities();
            // Call the LoadAsync method to asynchronously get the data for the given DbSet from the database.
            dbContext.TB_Pur.LoadAsync().ContinueWith(loadTask =>
            {
    // Bind data to control when loading complete
    gridControl1.DataSource = dbContext.TB_Pur.Local.ToBindingList();
            }, System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void FRM_CAT_Load(object sender, EventArgs e)
        {

        }
        //ADD
        private void btn_add_Click(object sender, EventArgs e)
        {
            PL.FRM_PUR_ADD frm_add = new PL.FRM_PUR_ADD();
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
            id =Convert.ToInt32( gridView1.GetFocusedRowCellValue("ID"));
            if(id > 0)
            { 
              try
              {
                 var rs = MessageBox.Show("عملية حدف", "هل انت متأكد من عملية الحدف", MessageBoxButtons.YesNo);
                 if(rs==DialogResult.Yes)
                 {
                      tb_pur = db.TB_Pur.Where(x => x.ID == id).FirstOrDefault();
                      db.Entry(tb_pur).State = EntityState.Deleted;
                      db.SaveChanges();
                      toast.txt_capation.Text = "تم حذف عملية الشراء";
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
                dialog.txt_capation.Text = "لا توجد عملية شراء لحدفها";
                dialog.Width = this.Width;
                dialog.Show();

            }
        }

        private void Update_data()
        {
            db = new DB_SMPEntities();
             gridControl1.DataSource = db.TB_Pur.ToList();
        }

        //Edit
        //قال عملية تعديل تشبه الاضافة
        private void btn_edit_Click(object sender, EventArgs e)
        {
            PL.FRM_PUR_ADD frm_add = new PL.FRM_PUR_ADD();// 2- بتعدها

            id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ID"));// -3
            tb_pur = db.TB_Pur.Where(x => x.ID == id).FirstOrDefault();//

            frm_add.edit_name.Text = tb_pur.Pur_Name;
            frm_add.edt_type.Text = tb_pur.Pur_Type;
            frm_add.edt_cat.Text = tb_pur.Pur_Cat;
            frm_add.edt_supp.Text = tb_pur.Pur_Supp;
            frm_add.edt_buy.Text = tb_pur.Pur_Buy.ToString();
            frm_add.edt_sell.Text = tb_pur.Pur_Sell.ToString();
            frm_add.edt_qt.Text = tb_pur.Pur_Qt.ToString();
            frm_add.edt_tsell.Text = tb_pur.Pur_Tsell.ToString();
            frm_add.edt_tbuy.Text = tb_pur.Pur_Tbuy.ToString();
            frm_add.edt_trve.Text = tb_pur.Pur_TRve.ToString();

            frm_add.id = id;
            frm_add.btn_add.Text = "تعديل";
            frm_add.Show();
        }
        
        //private void btn_serachh()
        //{
        //    var _search = edit_serch.Text;
        //    gridControl1.DataSource = db.TB_Pur.Where(x => x.Pur_Name.Contains(_search) || x.Pur_Type.Contains(_search) || x.Pur_Cat.Contains(_search)).ToList();//تقدر ضيف باقي الحقول بنفس الطريقة 
        //}
        private void btn_serach_Click(object sender, EventArgs e)
        {
            var _search = edit_serch.Text;
            gridControl1.DataSource=db.TB_Pur.Where(x=>x.Pur_Name.Contains(_search) || x.Pur_Type.Contains(_search) || x.Pur_Cat.Contains(_search)).ToList();
            //تقدر اطيف باقي الحقول بنفس الطريقة للبحث عليهم --->انضر

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void edit_serch_TextChanged(object sender, EventArgs e)
        {
            //تقدر تحط الدلة لدرتها انا بش تبداء تبحث مغير متضغط علي زرالبتن
        }
    }
    }
