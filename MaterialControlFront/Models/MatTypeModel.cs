using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaterialControlFront.Models
{
    public class MatTypeModel
    {
        [Key]
        public int Type_Id { get; set; }
        
        [Required(ErrorMessage = "กรุณาระบุชื่อ Material Type")]
        [DisplayName("รหัสประเภท Materail Type")]
        public string Type_Code { get; set; }

        [Required(ErrorMessage = "กรุณาระบุประเภท Material Name")]
        [DisplayName("ชื่อประเภท Materail")]
        public string Type_Name { get; set;}
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Type_Remark { get; set;}
    }
}