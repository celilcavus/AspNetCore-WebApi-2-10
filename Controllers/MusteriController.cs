using Microsoft.AspNetCore.Mvc;
using Model.Contexts;
using Model.Entity;

namespace KargoTakipApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class MusteriController : ControllerBase
    {
        KargoTakipContext rep = new KargoTakipContext();
        [HttpGet]
        public IActionResult GetMusteriList()
        {
            var GetMusteri = rep.Musteris!.ToList();

            if (!string.IsNullOrEmpty(GetMusteri.ToString()))
            {
                return Ok(GetMusteri);
            }
            else return NotFound();

        }

        [HttpGet("{id}")]
        public IActionResult GetMusteriList(int? id)
        {
            int NullOrEmpty = id ?? 0;
            if (NullOrEmpty != 0)
            {
                var GetMusteri = rep.Musteris!.Where(x => x.Id == id).FirstOrDefault();

                if (!string.IsNullOrEmpty(GetMusteri!.ToString()))
                {
                    return Ok(GetMusteri);
                }
                else return NotFound();
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult PostMusteri(Musteri musteri)
        {
            if (!string.IsNullOrEmpty(musteri.ToString()))
            {
                rep.Musteris!.Add(musteri);
                rep.SaveChanges();
                return NoContent();
            }
            else return NotFound();

        }

        [HttpPut]
        public IActionResult PutMusteri(Musteri musteri)
        {
            if (!string.IsNullOrEmpty(musteri.ToString()))
            {
                var getMusteriValue = rep.Musteris!.Where(x => x.Id == musteri.Id).First();
                if (!string.IsNullOrEmpty(getMusteriValue.ToString()))
                {
                    rep.Musteris!.Add(musteri);
                    rep.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMusteri(int? id)
        {
            int NullOrEmpty = id ?? 0;
            if (NullOrEmpty != 0)
            {
                var GetMusteri = rep.Musteris!.Where(x => x.Id == id).FirstOrDefault();

                if (!string.IsNullOrEmpty(GetMusteri!.ToString()))
                {
                   rep.Musteris!.Remove(GetMusteri);
                   rep.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();
        }
    }
}