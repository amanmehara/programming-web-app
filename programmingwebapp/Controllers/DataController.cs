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
using programmingwebapp.Models;

namespace programmingwebapp.Controllers
{
    public class DataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Data
        public IQueryable<Program> GetPrograms()
        {
            return db.Programs;
        }

        // GET: api/Data/5
        [ResponseType(typeof(Program))]
        public IHttpActionResult GetProgram(Guid id)
        {
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                return NotFound();
            }

            return Ok(program);
        }

        // PUT: api/Data/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProgram(Guid id, Program program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != program.ProgramId)
            {
                return BadRequest();
            }

            db.Entry(program).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(id))
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

        // POST: api/Data
        [ResponseType(typeof(Program))]
        public IHttpActionResult PostProgram(Program program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Programs.Add(program);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProgramExists(program.ProgramId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = program.ProgramId }, program);
        }

        // DELETE: api/Data/5
        [ResponseType(typeof(Program))]
        public IHttpActionResult DeleteProgram(Guid id)
        {
            Program program = db.Programs.Find(id);
            if (program == null)
            {
                return NotFound();
            }

            db.Programs.Remove(program);
            db.SaveChanges();

            return Ok(program);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgramExists(Guid id)
        {
            return db.Programs.Count(e => e.ProgramId == id) > 0;
        }
    }
}