using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Genoma.Models;
using TechnicalTest.Data;
using Newtonsoft.Json;
using System.Web.UI.WebControls;

namespace TechnicalTest.Controllers
{
    public class PeopleController : Controller
    {
        private TechnicalTestContext db = new TechnicalTestContext();

        // GET: People
        public ActionResult Index()
        {
            var url = "https://torre.bio/api/bios/giganteg";
            Genoma.Models.Root Persona = _download_serialized_json_data<Genoma.Models.Root>(url);
            return View(Persona);
//            return View(db.People.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                id = "giganteg";
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var url = "https://torre.bio/api/bios/" + id;
            Genoma.Models.Root Persona =  _download_serialized_json_data<Genoma.Models.Root>(url);

            //            Person person = db.People.Find(id);
            //Genoma.Models.Root Persona = JsonConvert.DeserializeObject<Genoma.Models.Root>(url);
            if (Persona == null)
            {
                return HttpNotFound();
            }
            return View(Persona);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,professionalHeadline,completion,showPhone,created,verified,flags,weight,locale,subjectId,picture,hasEmail,isTest,name,location,theme,pictureThumbnail,claimant,summaryOfBio,weightGraph,publicId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,professionalHeadline,completion,showPhone,created,verified,flags,weight,locale,subjectId,picture,hasEmail,isTest,name,location,theme,pictureThumbnail,claimant,summaryOfBio,weightGraph,publicId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
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
