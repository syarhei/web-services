using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ws_lab_03.Models {
    public class Student {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(30, ErrorMessage = "Fullname lenght is more 30 symbols")]
        public string name { get; set; }
        [StringLength(30, ErrorMessage = "Phone lenght is more 30 symbols")]
        public string phone { get; set; }
    }
}