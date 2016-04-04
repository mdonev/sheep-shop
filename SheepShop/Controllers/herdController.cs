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
using SheepShop.Context;
using SheepShop.Models;

namespace SheepShop.Controllers
{
    public class herdController : ApiController
    {
        private HerdContext db = new HerdContext();

        // GET: api/herd
        public IQueryable<Herd> Getherd()
        {
            return db.herd;
        }

        // GET: api/herd/5
        [ResponseType(typeof(Herd))]
        public IHttpActionResult GetHerd(int id)
        {
            Herd herd = db.herd.Find(id);
            if (herd == null)
            {
                return NotFound();
            }

            return Ok(herd);
        }

        // PUT: api/herd/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHerd(int id, Herd herd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != herd.ID)
            {
                return BadRequest();
            }

            db.Entry(herd).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HerdExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/herd
        [ResponseType(typeof(Herd))]
        public IHttpActionResult PostHerd(Herd herd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.herd.Add(herd);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = herd.ID }, herd);
        }

        // DELETE: api/herd/5
        [ResponseType(typeof(Herd))]
        public IHttpActionResult DeleteHerd(int id)
        {
            Herd herd = db.herd.Find(id);
            if (herd == null)
            {
                return NotFound();
            }

            db.herd.Remove(herd);
            db.SaveChanges();

            return Ok(herd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HerdExists(int id)
        {
            return db.herd.Count(e => e.ID == id) > 0;
        }
    }
}