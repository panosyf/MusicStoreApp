using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStoreApp.Models;

namespace MusicStoreApp.Controllers
{
    public class MediaTypesController : Controller
    {
        private ChinookEntities db = new ChinookEntities();

        // GET: MediaTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.MediaTypes.ToListAsync());
        }

        // GET: MediaTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaType mediaType = await db.MediaTypes.FindAsync(id);
            if (mediaType == null)
            {
                return HttpNotFound();
            }
            return View(mediaType);
        }

        // GET: MediaTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MediaTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MediaTypeId,Name")] MediaType mediaType)
        {
            if (ModelState.IsValid)
            {
                db.MediaTypes.Add(mediaType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mediaType);
        }

        // GET: MediaTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaType mediaType = await db.MediaTypes.FindAsync(id);
            if (mediaType == null)
            {
                return HttpNotFound();
            }
            return View(mediaType);
        }

        // POST: MediaTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MediaTypeId,Name")] MediaType mediaType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediaType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mediaType);
        }

        // GET: MediaTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaType mediaType = await db.MediaTypes.FindAsync(id);
            if (mediaType == null)
            {
                return HttpNotFound();
            }
            return View(mediaType);
        }

        // POST: MediaTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MediaType mediaType = await db.MediaTypes.FindAsync(id);
            db.MediaTypes.Remove(mediaType);
            await db.SaveChangesAsync();
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
    }
}
