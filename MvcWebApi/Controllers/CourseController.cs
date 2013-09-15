using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net.Http;
using System.Net;

namespace MvcWebApi.Controllers
{
    public class CourseController : ApiController
    {
        //
        // GET: /Course/
        public IEnumerable<Course> Get()
        {
            System.Threading.Thread.Sleep(3000);

            return courses;
        }

        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage msg = null;

            var ret = (from c in courses
                       where c.id == id
                       select c).FirstOrDefault();

            //return 404 if not found
            if (ret == null)
            {
                msg = Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else 
            {
                msg = Request.CreateResponse<Course>(HttpStatusCode.OK, ret);
            }

            return msg;
        }

        public HttpResponseMessage Post([FromBody]Course c)
        {
            c.id = courses.Count;
            courses.Add(c);

            var msg = Request.CreateResponse(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + "/" + c.id.ToString());

            return msg;
        }

        public void Put(int id, [FromBody]Course course) 
        {
            var ret = (from c in courses
                       where c.id == id
                       select c).FirstOrDefault();
            ret.title = course.title;
        }

        public void Delete(int id)
        {
            var ret = (from c in courses
                       where c.id == id
                       select c).FirstOrDefault();
            courses.Remove(ret);

        }


        static List<Course> courses = InitCourses();

        private static List<Course> InitCourses()
        {
            var ret = new List<Course>();
            ret.Add(new Course { id = 0, title = "Course 1" });
            ret.Add(new Course { id = 1, title = "Course 2" });

            return ret;
        }
    }

    public class Course
    {
        public int id;
        public string title;
    }
}
