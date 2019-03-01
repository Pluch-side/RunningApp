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
        public ActionResult CreateOrUpdate(int courseID = 0, int poiID = 0)
        {
            var pois = this._business.GetByCourseID(courseID);
            int orderPOI = 1;
            if (pois.Count > 0)
                orderPOI = pois.Max(item => item.OrderPOI) + 1;
            PointOfInterest newPOI = new PointOfInterest() { OrderPOI = orderPOI };
            if (poiID > 0)
            {
                newPOI = this._business.Get(poiID);
                courseID = (int)newPOI.CourseID;
            }
            var typesPOI = new TypePOIBLL().GetAll();
            ViewBag.pois = pois;
            ViewBag.typesPOI = typesPOI.ToList();
            ViewBag.courseID = courseID;
            int typeSelected = 1;
            PointOfInterest poi = pois.Where(p => p.TypePOIID == 1).FirstOrDefault();
            if (poi != null)
            {
                typeSelected = 3;
            }
            ViewBag.typeSelected = typeSelected;
            return View(newPOI);
        }

        // POST: POI/Create
        [HttpPost]
        public ActionResult CreateOrUpdate(PointOfInterest poi)
        {
            try
            {
                if (poi.ID > 0)
                {
                    this._business.Update(poi);
                }
                else
                {
                    this._business.Add(poi);
                }

                return RedirectToAction("CreateOrUpdate", new { poi.CourseID }); ;
            }
            catch(Exception e)
            {
                return RedirectToAction("CreateOrUpdate", new { poi.CourseID });
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
            try
            {
                PointOfInterest poi = this._business.Get(id);
                int courseId = (int)this._business.Get(id).CourseID;
                this._business.RemoveByID(id);
                return RedirectToAction("CreateOrUpdate", new { courseId });
            }
            catch
            {
                return this.View();
            }
        }
    }
}
