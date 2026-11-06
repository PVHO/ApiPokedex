using ApiPokedex.Models;
using System.Linq;
using System.Web.Http;

namespace ApiPokedex.Controllers
{
    public class EntrenadoresController : ApiController
    {
        private PokedexContext db = new PokedexContext();

        // GET: api/entrenadores
        public IHttpActionResult Get()
            => Ok(db.Entrenadores.ToList());

        // GET: api/entrenadores/5
        public IHttpActionResult Get(int id)
        {
            var e = db.Entrenadores.Find(id);
            return e == null ? (IHttpActionResult)NotFound() : Ok(e);
        }

        // POST: api/entrenadores
        public IHttpActionResult Post(Entrenador est)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            db.Entrenadores.Add(est);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = est.EntrenadorId }, est);
        }

        // PUT: api/entrenadores/5
        public IHttpActionResult Put(int id, Entrenador est)
        {
            var e = db.Entrenadores.Find(id);
            if (e == null) return NotFound();
            e.Nombre = est.Nombre; e.Edad = est.Edad;
            db.SaveChanges();
            return Ok(e);
        }

        // DELETE: api/entrenadores/5
        public IHttpActionResult Delete(int id)
        {
            var e = db.Entrenadores.Find(id);
            if (e == null) return NotFound();
            db.Entrenadores.Remove(e);
            db.SaveChanges();
            return Ok("Entrenador eliminado correctamente");
        }

        // Libera la conexión a la base de datos
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}