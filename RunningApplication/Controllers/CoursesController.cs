using BO;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunningApplication.Controllers
{
    public class CourseController : Controller
    {
        private CourseBLL _courseBusiness = new CourseBLL();

        // GET: Course
        public ActionResult Index()
        {
            var courses = this._courseBusiness.GetAll();
            return View(courses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            Course courseDetails = this._courseBusiness.Get(id);
            return View(courseDetails);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            var typesCourse = new TypeCourseBLL().GetAll();
            ViewBag.typesCourse = typesCourse.ToList();
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                course.ApplicationUserID = 1;
                this._courseBusiness.Add(course);
                return RedirectToRoute("CreateRouteAddPosition", new { controller = "POI", action = "Create", courseID = course.ID });
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            Course courseToUpdate = this._courseBusiness.Get(id);
            var typesCourse = new TypeCourseBLL().GetAll();
            ViewBag.typesCourse = typesCourse.ToList();
            return View(courseToUpdate);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Course course)
        {
            try
            {
                this._courseBusiness.Update(course);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            Course courseToDelete = this._courseBusiness.Get(id);
            return View(courseToDelete);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Course course)
        {
            try
            {
                this._courseBusiness.Remove(course);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
