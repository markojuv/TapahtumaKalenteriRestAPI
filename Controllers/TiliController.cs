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
    public class TiliController : ControllerBase
    {
        Kayttaja k = new Kayttaja();
        // GET: api/Tili
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Tili/5
        //[HttpGet("{id}", Name = "Get")]
        //public OmatTapahtumat HaeOmat(int kayttajaId, int tapahtumaId)
        //{
        //    using (EventDBContext db = new EventDBContext())
        //    {
        //        OmatTapahtumat o;
        //        o.KayttajaId = db.Kayttajat.Where(a => a.KayttajaId == kayttajaId).FirstOrDefault();
        //        var tapahtuma = db.Tapahtumat.Where(a => a.TapahtumaId == tapahtumaId).FirstOrDefault();
                
                
        //    }
        //}
        //[HttpGet("{id}", Name = "Get")]
        //public Tapahtumat Get(int id)
        //{
        //    using (EventDBContext db = new EventDBContext())
        //    {
        //        Tapahtumat t = db.Tapahtumat.Where(a => a.TapahtumaId == id).FirstOrDefault();
        //        return t;

        //    }
        //}

        // POST: api/Tili
        [HttpPost]
        public void Post([FromBody] Kayttajat kayttaja)
        {
            using (EventDBContext db = new EventDBContext())
            {
                db.Kayttajat.Add(kayttaja);
                db.SaveChanges();
            }
        }

        // PUT: api/Tili/5
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
