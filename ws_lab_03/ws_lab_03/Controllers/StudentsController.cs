using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using ws_lab_03.Models;

namespace ws_lab_03.Controllers
{
    public class StudentsController : ApiController
    {

        private StudentList db = new StudentList();

        // GET: api/Students
        [HttpGet]
        public object GetStudents(string[] parameters)
        {
            IQueryable<Student> students = db.Students;

            // Get params from query
            var requestParams = Request.GetQueryNameValuePairs();
            var limit = requestParams.Where(p => p.Key == "limit").ToList();
            var offset = requestParams.Where(p => p.Key == "offset").ToList();
            var sort = requestParams.Where(p => p.Key == "sort").ToList();
            var minid = requestParams.Where(p => p.Key == "minid").ToList();
            var maxid = requestParams.Where(p => p.Key == "maxid").ToList();
            var global_like = requestParams.Where(p => p.Key == "global_like").ToList();
            var columns = requestParams.Where(p => p.Key == "columns").ToList();

            // Sort by id, name, phone
            if (sort.Count() == 1)
                students = (sort[0].Value == "name" ? students.OrderBy(s => s.name)
                    : sort[0].Value == "phone" ? students.OrderBy(s => s.phone)
                    : students.OrderBy(s => s.id));
            else
                students = students.OrderBy(s => s.id);

            // Filter by min or max id
            if (minid.Count() == 1) { int min = int.Parse(minid[0].Value); students = students.Where(s => s.id >= min); }
            if (maxid.Count() == 1) { int max = int.Parse(maxid[0].Value); students = students.Where(s => s.id <= max); }

            // Search students by name
            if (global_like.Count() == 1) {
                string g_like = global_like[0].Value;
                students = students.Where(s => s.name.Contains(g_like) || s.phone == g_like);
            }

            // Pagination
            if (limit.Count() == 1 && offset.Count() == 1)
                students = students.Skip(((int.Parse(offset[0].Value)) - 1) * int.Parse(limit[0].Value)).Take(int.Parse(limit[0].Value));

            var list = students.ToList();

            //// Filter columns
            //if (columns.Count() == 1) {
            //    string column_lavue = columns[0].Value;
            //    string[] arr = column_lavue.Split(",".ToCharArray());
            //    bool id = false, name = false, phone = false;

            //    foreach (string val in arr) {
            //        if (val == "id") id = true;
            //        if (val == "name") name = true;
            //        if (val == "phone") phone = true;
            //    }
                    
            //    list.ForEach(s => listApi_.Add(new {  });
            //}
            

            // Add HateOAS
            List<StudentApi> listApi = new List<StudentApi>();
            list.ForEach(s => listApi.Add(new StudentApi(s, new HateOAS("http://localhost:65191/api/Students/" + s.id, "student." + s.id))));

            return Ok(listApi);
        }

        // GET: api/Students/5
        [HttpGet]
        [ResponseType(typeof(Student))]
        public object GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
                return Content(HttpStatusCode.NotFound, new HateOAS("http://localhost:65191/api/Errors/404", "error.404"));

            return Ok(new StudentApi(student, new HateOAS("http://localhost:65191/api/Students/" + id, "self")));
        }

        // PUT: api/Students/5
        [HttpPut]
        [ResponseType(typeof(Student))]
        public object PutStudent(int id, Student student) {
            student.id = id;

            if (!ModelState.IsValid) {
                return Content(HttpStatusCode.BadRequest, new { ModelState, hateoas = new HateOAS("http://localhost:65191/api/Errors/400", "error.400") });
            }

            try {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return Content(HttpStatusCode.OK, new StudentApi(student, new HateOAS("http://localhost:65191/api/Students/" + student.id, "self")));
            } catch (DbUpdateConcurrencyException) {
                if (!StudentExists(id)) {
                    return Content(HttpStatusCode.NotFound, new HateOAS("http://localhost:65191/api/Errors/404", "error.404"));
                } else {
                    throw;
                }
            }
        }

        // POST: api/Students
        [HttpPost]
        [ResponseType(typeof(Student))]
        public object PostStudent(Student student)
        {
            if (!ModelState.IsValid)
                return Content(HttpStatusCode.BadRequest, new { ModelState, hateoas = new HateOAS("http://localhost:65191/api/Errors/400", "error.400") });

            db.Students.Add(student);
            db.SaveChanges();

            return Content(HttpStatusCode.Created, new StudentApi(student, new HateOAS("http://localhost:65191/api/Students/" + student.id, "self")));
        }

        // DELETE: api/Students/5
        [HttpDelete]
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
                return Content(HttpStatusCode.NotFound, new HateOAS("http://localhost:65191/api/Errors/404", "error.404"));

            db.Students.Remove(student);
            db.SaveChanges();

            return Content(HttpStatusCode.NoContent, new HateOAS("http://localhost:65191/api/Students/" + id, "self"));
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.id == id) > 0;
        }
    }
}