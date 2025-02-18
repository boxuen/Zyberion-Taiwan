using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zyberion_Taiwan
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            using (var db = new ZCharge_PlanEntities())
            {
                //將binding source內的資料來源顯示出來
                carBindingSource.DataSource = db.Car.ToList();
                carBrandBindingSource.DataSource = db.CarBrand.ToList();
                carDisplayBindingSource.DataSource = db.CarDisplay.ToList();
                
                //顯示廠牌下拉選單內容 (EX：L7 - Zyberion Taiwan )
                using (var db2 = new ZCharge_PlanEntities())
                {
                    var result = (from cb in db2.CarBrand
                                  select new
                                  {
                                      result = cb.BrandNo + " - " + cb.BrandName,
                                  }).Distinct();
                    var c = result.ToList();
                    foreach (var item in result)
                    {
                        comboBox1.Items.Add(item.result);
                    }
                    //顯示載客人數combox
                    var seat_num =( from cd in db2.CarDisplay
                                   select new
                                   {
                                       cd.SeatNumber,
                                   }).Distinct().ToList();
                    foreach(var item in seat_num)
                    {
                        comboBox2.Items.Add(item.SeatNumber);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //車型查詢
            using (var db = new ZCharge_PlanEntities())
            {
                var car_result = (from c in db.Car
                                  join cd in db.CarDisplay on c.Car_id equals cd.ID
                                  join cb in db.CarBrand on cd.Brand_id equals cb.ID
                                  select new
                                  {
                                      Column1 = cb.BrandNo,
                                      Column2 = cb.BrandName,
                                      Column3 = cd.Display_no,
                                      Column4 = cd.Content,
                                      Column5 = cd.Engine,
                                      Column6 = cd.SeatNumber,
                                      Column7 = c.Year,
                                      Column8 = "V",
                                  });
                dataGridView1.DataSource = car_result.ToList();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            

        }
    }
}
    
    
    

