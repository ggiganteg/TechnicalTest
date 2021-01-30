using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Job.Models;
using Newtonsoft.Json;

namespace TechnicalTest.Data
{
    public class AdvertisementsController : Controller
    {
        private TechnicalTestContext db = new TechnicalTestContext();

        // GET: Advertisements
        public ActionResult Index()
        {
            var id = "qdPXJ8db";

            var url = "https://torre.co/api/opportunities/" + id;

            Advertisement advertisement = null;
            return View(advertisement);
        }

        // GET: Advertisements/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                id = "qdPXJ8db";
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var url = "https://torre.co/api/opportunities/" + id;

            Advertisement advertisement = _download_serialized_json_data<Advertisement>(url);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            return View(advertisement);
        }


        // GET: Advertisements/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Advertisement advertisement = await db.Advertisements.FindAsync(id);
            if (advertisement == null)
            {
                return HttpNotFound();
            }
            ViewBag.status = new SelectList(db.PrefilledStatus, "status", "status", advertisement.status);
            return View(advertisement);
        }

        // POST: Advertisements/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,boardVersion,locale,objective,review,deadline,slug,completion,created,crawled,opportunity,active,stableOn,openGraph,status")] Advertisement advertisement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(advertisement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.status = new SelectList(db.PrefilledStatus, "status", "status", advertisement.status);
            return View(advertisement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception e)
                {
                    throw e;
                }
                // if string with JSON data is not empty, deserialize it to class and return its instance
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
    }
}
