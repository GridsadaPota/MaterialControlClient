using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialControlFront.Models
{
    public class MatTypeModelView
    {
        public int Type_Id { get; set; }
        public string Type_Code { get; set; }
        public string Type_Name { get; set; }
        public string Type_Remark { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Modify_Date { get; set; }
    }
}