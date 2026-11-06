using ApiPokedex.Models;
using System.Linq;
using System.Web.Http;

namespace ApiPokedex.Controllers
{
    public class PokemonController : ApiController
    {
        private PokedexContext db = new PokedexContext();

        // GET: api/pokemon
        public IHttpActionResult Get()
            => Ok(db.Pokemones.ToList());

        // GET: api/pokemon/5
        public IHttpActionResult Get(int id)
        {
            var m = db.Pokemones.Find(id);
            return m == null ? (IHttpActionResult)NotFound() : Ok(m);
        }

        // POST: api/pokemon
        public IHttpActionResult Post(Pokemon mat)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            db.Pokemones.Add(mat);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = mat.PokemonId }, mat);
        }

        // PUT: api/pokemon/5
        public IHttpActionResult Put(int id, Pokemon mat)
        {
            var m = db.Pokemones.Find(id);
            if (m == null) return NotFound();
            m.Nombre = mat.Nombre; m.Nivel = mat.Nivel;
            db.SaveChanges();
            return Ok(m);
        }

        // DELETE: api/pokemon/5
        public IHttpActionResult Delete(int id)
        {
            var m = db.Pokemones.Find(id);
            if (m == null) return NotFound();
            db.Pokemones.Remove(m);
            db.SaveChanges();
            return Ok("Pokémon liberado correctamente");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}