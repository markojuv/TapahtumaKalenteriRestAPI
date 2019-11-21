﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpGet("Search/{nimi}", Name = "Search")]
        public IEnumerable<Tapahtumat> GetByName(string nimi)
        {
            using (EventDBContext db = new EventDBContext())
            {
                var tapahtuma = db.Tapahtumat.Where(a => a.Nimi.ToLower().Contains(nimi.ToLower())).ToList();
                return tapahtuma;

            }
        }

        // POST: api/Tapahtuma
        [HttpPost]
        public void Post([FromBody] Tapahtumat tapahtumat)
        {
            using (EventDBContext db = new EventDBContext())
            {
                var paikkapalvelu = new GoogleLocationService(Environment.GetEnvironmentVariable("APIKey"));
                var latlong = paikkapalvelu.GetLatLongFromAddress(tapahtumat.Sijainti);
                tapahtumat.Lat = latlong.Latitude;
                tapahtumat.Long = latlong.Longitude;
                db.Tapahtumat.Add(tapahtumat);
                db.SaveChanges();
            }
        }

        // PUT: api/Tapahtuma/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Tapahtumat tapahtumat)
        {
            using (EventDBContext db = new EventDBContext())
            {
                Tapahtumat t = db.Tapahtumat.Find(id);
                var paikkapalvelu = new GoogleLocationService(Environment.GetEnvironmentVariable("APIKey"));
                var latlong = paikkapalvelu.GetLatLongFromAddress(t.Sijainti);
                t.Lat = latlong.Latitude;
                t.Long = latlong.Longitude;
                t.Hinta = tapahtumat.Hinta;
                t.Ikäraja = tapahtumat.Ikäraja;
                t.Kategoria = tapahtumat.Kategoria;
                t.Kuva = tapahtumat.Kuva;
                t.Kuvaus = tapahtumat.Kuvaus;
                t.Linkki = tapahtumat.Linkki;
                t.Nimi = tapahtumat.Nimi;
                t.Päivämäärä = tapahtumat.Päivämäärä;
                t.Sijainti = tapahtumat.Sijainti;
                db.SaveChanges();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (EventDBContext db = new EventDBContext())
            {
                Tapahtumat t = db.Tapahtumat.Find(id);

                db.Tapahtumat.Remove(t);
                db.SaveChanges();

            }
        }


    }
}
