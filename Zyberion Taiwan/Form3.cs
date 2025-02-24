using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zyberion_Taiwan
{
    public partial class Form3 : Form
    {
        public Form3(string  id,long carid)
        {
            InitializeComponent();
            //透過儲存的id內容，抓取相對應的車子資料
            using (var db = new ZCharge_PlanEntities())
            {
                var result = (from c in db.Car
                              join cd in db.CarDisplay on c.Car_id equals cd.ID
                              join cr in db.ChargingRecord on c.ID equals cr.Car_id into crGroup
                              from cr in crGroup.DefaultIfEmpty() // 允許沒有充電記錄的車輛仍然顯示
                              where cd.Display_Name == id
                              group cr by new
                              {
                                  id,
                                  c.Car_number,
                                  cd.Price,
                                  c.Date,
                                  c.National,
                                  c.Color,
                                  cd.Battery_Capacity,
                                  cd.Engine,
                                  c.Health,
                                  cd.Motor_Power,

                              } into g
                              select new
                              {
                                  g.Key.id,
                                  g.Key.Car_number,
                                  g.Key.Price,
                                  g.Key.Date,
                                  g.Key.National,
                                  g.Key.Color,
                                  g.Key.Battery_Capacity,
                                  g.Key.Engine,
                                  g.Key.Health,
                                  g.Key.Motor_Power,
                                  total_record_count = g.Count(cr => cr != null) // 正確計算充電記錄數量，允許 NULL
                }).ToList();

                if (result.Count > 0)
                {
                    label1.Text = "車體型號：" + result[0].id;
                    label2.Text = "車體號碼：" + result[0].Car_number;
                    label3.Text = "建議售價：" + result[0].Price + "（美元）";
                    label4.Text = "出廠日期：" + result[0].Date.ToString();
                    label5.Text = "出廠國別：" + result[0].National;
                    label6.Text = "色系：" + result[0].Color;
                    label7.Text = "電池容量："+ result[0].Battery_Capacity;
                    label8.Text = "馬達功率："+ result[0].Motor_Power;
                    label9.Text = "電池健康度：" + result[0].Health;
                    label10.Text = "充電紀錄（共" + result[0].total_record_count + "次）：";
                    
                }
                
                var record = (from cr in db.ChargingRecord
                              where cr.Car_id == carid
                              select new
                              {
                                  Column7 = Guid.NewGuid(), // 自動產生新的guid
                                  Column1 = cr.Charging_Start_Time,
                                  Column2 = cr.Charging_End_Time,
                                  Column3 = cr.Charging_Start_Capacity,
                                  Column4 = cr.Charging_End_Capacity,
                                  Column5 = cr.Charging_Minutes,
                                  Column6 = cr.Remaining_Capacity,
                              }).ToList();
                dataGridView1.DataSource = record;


            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        // 將Datagridview內容=>JSON
        private void Export(DataGridView dataGridView, string filepath)
        {
            try
            {
                //這行程式碼的作用是建立一個 List<Dictionary<string, object>> 來存儲 DataGridView 中的資料。
                List<Dictionary<string,object>> rows = new List<Dictionary< string,object>>();
                foreach(DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        Dictionary<string, object> rowdata = new Dictionary<string, object>();
                        foreach(DataGridViewCell cell in row.Cells)
                        {
                            string column = dataGridView.Columns[cell.ColumnIndex].Name;
                            //這行程式碼的作用是將 DataGridView 單元格 (Cell) 的資料存入 Dictionary<string, object>，並處理 null 值的情況。
                            rowdata[column] = cell.Value??DBNull.Value;
                        }
                        rows.Add(rowdata);
                        
                        
                        // 將 List 轉換為 JSON 格式，並使用 Formatting.Indented(縮排) 讓 JSON 格式化輸出
                        string json = JsonConvert.SerializeObject(rows,Formatting.Indented);
                        File.WriteAllText(filepath, json);
                        MessageBox.Show("Export to Json Successful !!!");

                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error!!!!" + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
           //開啟儲存對話框
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "儲存檔案";
               // saveFileDialog.FileName = "Export JSON.json";
            }

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFileDialog1.FileName;
                Export(dataGridView1,filepath);
            }
        }
    }
}
