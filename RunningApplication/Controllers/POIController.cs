using BO;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RunningApplication.Controllers
{
    public class POIController : Controller
    {
        private PointOfInterestBLL _business = new PointOfInterestBLL();

        // GET: POI
        public ActionResult Index()
        {
            return View();
        }

        // GET: POI/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: POI/Create
        public ActionResult Create(int courseID, bool isOrder = false)
        {
            var pois = this._business.GetByCourseID(courseID);
            var typesPOI = new TypePOIBLL().GetAll();
            ViewBag.pois = pois;
            ViewBag.typesPOI = typesPOI.ToList();
            ViewBag.courseID = courseID;
            ViewBag.isOrder = isOrder;
            return View();
        }

        // POST: POI/Create
        [HttpPost]
        public ActionResult Create(PointOfInterest poi)
        {
            try
            {
                bool isOrder = _business.GetByOrder(poi.OrderPOI).Count > 0;
                ActionResult ret = RedirectToAction("Create", new { poi.CourseID, isOrder });

                if (!isOrder)
                {
                    _business.Add(poi);
                    ret = RedirectToAction("Create", new { poi.CourseID });
                }

                return ret;
            }
            catch
            {
                return RedirectToAction("Create", new { poi.CourseID });
            }
        }

        // GET: POI/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: POI/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: POI/Delete/5
        public ActionResult Delete(int id)
        {
            PointOfInterest poi = this._business.Get(id);
            return View(poi);
        }

        // POST: POI/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PointOfInterest poi)
        {
            try
            {
                int courseId = (int)this._business.Get(id).CourseID;
                this._business.RemoveByID(id);
                return RedirectToAction("Create", new { courseId });
            }
            catch
            {
                return View();
            }
        }
    }
}
