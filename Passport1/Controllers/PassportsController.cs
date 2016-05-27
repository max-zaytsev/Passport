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
using Passport1.Models;

namespace Passport1.Controllers
{
    public class PassportsController : ApiController
    {
        private Passport1Model db = new Passport1Model();

        // GET: api/Passports
        public IQueryable<Passport> GetPassports()
        {
            var c = db.Passports.Take(1);
            return c;
        }

        // GET: api/Passports/5
        [ResponseType(typeof(Passport))]
        public IHttpActionResult GetPassport(int id)
        {
            Passport passport = db.Passports.Find(id);
            if (passport == null)
            {
                return NotFound();
            }

            return Ok(passport);
        }

        // PUT: api/Passports/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPassport(int id, Passport passport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != passport.SeriesAndNumber)
            {
                return BadRequest();
            }

            db.Entry(passport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassportExists(id))
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

        // POST: api/Passports
        [ResponseType(typeof(Passport))]
        public IQueryable<ShortPasportInfo> PostPassport(Filter passport)
        {
            db.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));
            var query = db.Passports.Where(p => true);
            if (passport.Surname != null)
            {
                query = query.Where(p => p.Surname == passport.Surname);
            }
            if (passport.SeriesAndNumber != null)
            {
                query = query.Where(p => p.SeriesAndNumber == passport.SeriesAndNumber);
            }
            if (passport.Name != null)
            {
                query = query.Where(p => p.Name == passport.Name);
            }
            if (passport.PatronymicName != null)
            {
                query = query.Where(p => p.PatronymicName == passport.PatronymicName);
            }
            if (passport.SettlementOfBirth != null)
            {
                query = query.Where(p => p.SettlementOfBirth.name == passport.SettlementOfBirth);
            }

            var result = query.Select(p => new ShortPasportInfo
            {
                SeriesAndNumber = p.SeriesAndNumber,
                Surname = p.Surname,
                Name = p.Name,
                PatronymicName = p.PatronymicName,
                DateOfBirth = p.DateOfBirth,
                SettlementOfBirth = p.SettlementOfBirth.name       
            });

            



            return result;
        }

        // DELETE: api/Passports/5
        [ResponseType(typeof(Passport))]
        public IHttpActionResult DeletePassport(int id)
        {
            Passport passport = db.Passports.Find(id);
            if (passport == null)
            {
                return NotFound();
            }

            db.Passports.Remove(passport);
            db.SaveChanges();

            return Ok(passport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PassportExists(int id)
        {
            return db.Passports.Count(e => e.SeriesAndNumber == id) > 0;
        }
    }
}