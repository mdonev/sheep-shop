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
    public class stockController : ApiController
    {
        private HerdContext db = new HerdContext();

        // GET: api/stock
        public IQueryable<Herd> Getherd()
        {
            //var selectStock = from s in db.herd
            //                  select new Herd() { totalMilk = s.totalMilk, skinWool = s.skinWool  };

            //selectStock.AsEnumerable().Sum(o => o.totalMilk);
            //selectStock.AsEnumerable().Sum(o => o.skinWool);



            return db.herd;
        }

        // GET: api/stock/5
        [ResponseType(typeof(Herd))]
        public IHttpActionResult GetHerd(int id, int T)
        {
            Herd herd = db.herd.Find(id);
            if (herd == null)
            {
                return NotFound();
            }

            //var selectStock = from s in db.herd
            //                  select s;

            //    selectStock.Sum(f => f.totalMilk);
            //    selectStock.Sum(r => r.skinWool);


            //return Ok(selectStock);
            return Ok(herd);
        }

        // PUT: api/stock/5
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

        // POST: api/stock
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

        // DELETE: api/stock/5
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