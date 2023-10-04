using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialControlFront.Models
{
    public class MatTypeModel
    {
        public int type_id { get; set; }
        public string type_code { get; set; }
        public string type_name { get; set;}
        public string type_remark { get; set;}
        public DateTime create_date { get; set; }
        public DateTime modify_date { get; set;}
    }
}