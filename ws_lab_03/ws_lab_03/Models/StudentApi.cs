using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_lab_03.Models {
    public class StudentApi {

        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public HateOAS hateoas { get; set; }

        public StudentApi(Student stud, HateOAS hateoas) {
            id = stud.id;
            name = stud.name;
            phone = stud.phone;
            this.hateoas = hateoas;
        }
    }
}