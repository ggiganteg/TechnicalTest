using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Genoma.Models;
using TechnicalTest.Data;
using Newtonsoft.Json;

namespace TechnicalTest.Controllers
{
    public class CandidatesController : Controller
    {
        private TechnicalTestContext db = new TechnicalTestContext();

        // GET: Candidates/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                id = "giganteg";
             //   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var url = "https://torre.bio/api/bios/" + id;

            Candidate candidate = _download_serialized_json_data<Candidate>(url);

          
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);

        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = Candidates(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        private Candidate Candidates(string id)
        {
            throw new NotImplementedException();
        }

        // POST: Candidates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CandidateId")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(candidate);
        }


        // POST: Candidates/Delete/5

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
