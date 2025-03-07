using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class Users
    {
        public long ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string E_MAIL { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public Nullable<long> Sex { get; set; }
        public Nullable<long> Level_id { get; set; }
        public Nullable<long> Status { get; set; }
        public Nullable<System.DateTime> Creat_date { get; set; }
    }
}