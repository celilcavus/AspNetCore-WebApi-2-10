using Microsoft.AspNetCore.Mvc;
using Model.Contexts;
using Model.Entity;

namespace KargoTakipApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class SatisTemsilcisiController : ControllerBase
    {
        KargoTakipContext rep = new KargoTakipContext();
        [HttpGet]
        public IActionResult GetSatisTemsilcisi()
        {

            var returnValue = rep.SatisTemsilcisis!.ToList();
            if (!string.IsNullOrEmpty(returnValue.ToString()))
            {
                return Ok(returnValue);
            }
            else return NotFound();
        }

        [HttpGet("id")]
        public IActionResult GetSatisTemsilcisi(int? id)
        {
            int NullOrEmpty = id ?? 0;
            if (NullOrEmpty != 0)
            {
                var returnValue = rep.SatisTemsilcisis!.Where(x => x.Id == id).First();
                if (!string.IsNullOrEmpty(returnValue.ToString()))
                {
                    return Ok(returnValue);
                }
                else return NotFound();
            }
            else return NotFound();
        }
        [HttpPost]
        public IActionResult PostSatisTemsilcisi(SatisTemsilcisi satisTemsilcisi)
        {
            if (!string.IsNullOrEmpty(satisTemsilcisi.ToString()))
            {
                rep.SatisTemsilcisis!.Add(satisTemsilcisi);
                rep.SaveChanges();
                return NoContent();
            }
            else return NotFound();
        }

        [HttpPut]
        public IActionResult PutSatisTemsilcisi(SatisTemsilcisi satisTemsilcisi)
        {
            var returnSatisTemsilcisi = rep.SatisTemsilcisis!.Where(x => x.Id == satisTemsilcisi.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(returnSatisTemsilcisi!.ToString()))
            {
                if (!string.IsNullOrEmpty(satisTemsilcisi.ToString()))
                {
                    satisTemsilcisi.SatisTemsilcisiAd = satisTemsilcisi.SatisTemsilcisiAd;
                    satisTemsilcisi.SatisTemsilcisiSoyad = satisTemsilcisi.SatisTemsilcisiSoyad;
                    rep.SatisTemsilcisis!.Update(satisTemsilcisi);
                    rep.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();
        }
        [HttpDelete("id")]
        public IActionResult DeleteTemsilcisi(int? id)
        {
            int NullOrEmpty = id ?? 0;
            if (NullOrEmpty != 0)
            {
                var returnValue = rep.SatisTemsilcisis!.Where(x => x.Id == id).First();
                if (!string.IsNullOrEmpty(returnValue.ToString()))
                {
                    rep.SatisTemsilcisis!.Remove(returnValue);
                    rep.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();
        }

    }
}