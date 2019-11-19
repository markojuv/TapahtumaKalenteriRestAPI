using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TapahtumaLib;
using TapahtumaLib.Models;

namespace TapahtumaRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TapahtumaController : ControllerBase
    {
        Tapahtuma t = new Tapahtuma();
        // GET: api/Tapahtuma
        [HttpGet]
        public List<Tapahtumat> KaikkiTapahtumat()
        {
            using (EventDBContext db = new EventDBContext())
            {
                return t.KaikkiTapahtumat();

            }
        }

        // GET: api/Tapahtuma/5
        [HttpGet("{id}", Name = "Get")]
        public Tapahtumat Get(int id)
        {
            using (EventDBContext db = new EventDBContext())
            {
                Tapahtumat t = db.Tapahtumat.Where(a => a.TapahtumaId == id).FirstOrDefault();
                return t;
            }
        }

        // POST: api/Tapahtuma
        [HttpPost]
        public void Post([FromBody] Tapahtumat tapahtumat)
        {
            using (EventDBContext db = new EventDBContext())
            {
                db.Tapahtumat.Add(tapahtumat);
                db.SaveChanges();
            }
        }

        // PUT: api/Tapahtuma/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
