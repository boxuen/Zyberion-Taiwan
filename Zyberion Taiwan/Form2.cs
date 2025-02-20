using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
                
                //車型查詢 - 顯示廠牌下拉選單內容 (EX：L7 - Zyberion Taiwan )
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
                    //車型查詢 - 顯示載客人數combox
                    var seat_num =( from cd in db2.CarDisplay
                                   select new
                                   {
                                       cd.SeatNumber,
                                   }).Distinct().ToList();
                    foreach(var item in seat_num)
                    {
                        comboBox2.Items.Add(item.SeatNumber);
                    }

                    //車輛管理 - 顯示型號combox

                    var car_display = (from cd in db2.CarDisplay
                                       select new
                                       {
                                           cd.Display_Name,
                                       }).Distinct().ToList();
                    foreach(var item in car_display)
                    {
                        comboBox3.Items.Add(item.Display_Name);
                    }

                    //車輛管理 - 顯示出廠國別combox
                    var national = (from sc in db.Car
                                    select new
                                    {
                                        sc.National,
                                    }).Distinct().ToList();
                    foreach(var item in national)
                    {
                        comboBox4.Items.Add(item.National);
                    }


                    //車輛管理 - 顯示車型顏色

                    var color = (from co in db.Car
                                 select new
                                 {
                                     co.Color
                                 }).Distinct().ToList();
                    foreach(var item in color)
                    {
                        comboBox5.Items.Add(item.Color);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //車型查詢
            using (var db = new ZCharge_PlanEntities())
            {
                if (checkBox1.Checked)
                {
                    var car_result = (from c in db.Car
                                      join cd in db.CarDisplay on c.Car_id equals cd.ID
                                      join cb in db.CarBrand on cd.Brand_id equals cb.ID
                                      where cd.Engine == "純電動車" || comboBox1.Text == cb.BrandNo +" - " + cb.BrandName ||  comboBox2.Text == cd.SeatNumber.ToString()
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
                else
                {
                    var car_result = (from c in db.Car
                                      join cd in db.CarDisplay on c.Car_id equals cd.ID
                                      join cb in db.CarBrand on cd.Brand_id equals cb.ID
                                      where  comboBox1.Text == cb.BrandNo + " - " + cb.BrandName || comboBox2.Text == cd.SeatNumber.ToString()
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

        private void button3_Click(object sender, EventArgs e)
        {
            //車輛管理
            using (var db = new ZCharge_PlanEntities())
            {

                var result = (from c in db.Car join u in db.User on c.User_ID equals u.ID
                              join cd in db.CarDisplay on c.Car_id equals cd.ID
                              where (comboBox3.Text == "全部" || comboBox3.Text == cd.Display_Name) &&
                    (comboBox4.Text == "全部" || comboBox4.Text == c.Car_number) &&
                    (comboBox5.Text == "全部" || comboBox5.Text == u.Name)

                              select new
                              {
                                  Column9 = cd.Display_Name,
                                  Column10 = c.Car_number,
                                  Column11 = u.Name,
                                  Column18 = c.Date,
                                  Column12 = c.National,
                                  Column13 = c.Color,
                                  Column14 = cd.Battery_Capacity,
                                  Column15 = cd.Motor_Power,
                                  Column16 = c.Creat_time,
                                  Column17 = c.Health,
                              }).ToList();
                dataGridView2.DataSource = result;
            }
        
            }
        }
    }

    
    

