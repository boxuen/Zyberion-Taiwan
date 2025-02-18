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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //帳號密碼登錄驗證
            using (var db = new ZCharge_PlanEntities())
            {
                var login = (from u in db.User
                             join l in db.Level
                             on u.Level_id equals l.ZMember_ID
                             where usernameTextBox.Text == u.Username && passwordTextBox.Text == u.Password
                             select new
                             {

                                 u.Name,
                                 l.ZMember_name,
                                 u.Status,

                             }).ToList();
                if (login.Count > 0)
                {
                    var name = login.FirstOrDefault().Name;
                    var level_name = login.FirstOrDefault().ZMember_name;
                    var status = login.FirstOrDefault().Status;
                    if (status == 0)
                    {
                        label3.Text = "系統狀態為停用！";
                        return;
                    }
                    MessageBox.Show(name + "您好，歡迎使用本系統，您的會員等級為" + level_name);
                    var f2 = new Form2();
                    f2.ShowDialog();
                }
                else
                {
                    label3.Text = "帳號密碼錯誤，請重新在試！";
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
