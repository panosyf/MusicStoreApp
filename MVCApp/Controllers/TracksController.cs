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
    public class TracksController : Controller
    {
        private ChinookEntities db = new ChinookEntities();

        // GET: Tracks
        public async Task<ActionResult> Index()
        {
            var tracks = db.Tracks.Include(t => t.Album).Include(t => t.Genre).Include(t => t.MediaType);
            return View(await tracks.ToListAsync());
        }

        // GET: Tracks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = await db.Tracks.FindAsync(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title");
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TrackId,Name,AlbumId,MediaTypeId,GenreId,Composer,Milliseconds,Bytes,UnitPrice")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(track);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", track.AlbumId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name", track.MediaTypeId);
            return View(track);
        }

        // GET: Tracks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = await db.Tracks.FindAsync(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", track.AlbumId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name", track.MediaTypeId);
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TrackId,Name,AlbumId,MediaTypeId,GenreId,Composer,Milliseconds,Bytes,UnitPrice")] Track track)
        {
            if (ModelState.IsValid)
            {
                db.Entry(track).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Albums, "AlbumId", "Title", track.AlbumId);
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", track.GenreId);
            ViewBag.MediaTypeId = new SelectList(db.MediaTypes, "MediaTypeId", "Name", track.MediaTypeId);
            return View(track);
        }

        // GET: Tracks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Track track = await db.Tracks.FindAsync(id);
            if (track == null)
            {
                return HttpNotFound();
            }
            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Track track = await db.Tracks.FindAsync(id);
            db.Tracks.Remove(track);
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
