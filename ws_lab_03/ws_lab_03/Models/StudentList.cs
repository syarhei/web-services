using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ws_lab_03.Models {
    public class StudentList : DbContext {
        public DbSet<Student> Students { set; get; }
    }
}