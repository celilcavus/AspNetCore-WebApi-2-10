using Microsoft.AspNetCore.Mvc;
using Model.Contexts;
using Model.Entity;

namespace KargoTakipApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class UrunController : ControllerBase
    {
        KargoTakipContext rep = new KargoTakipContext();

        [HttpGet]
        public IActionResult GetUrunList()
        {
            var values = rep.Urun!.ToList();
            if (!string.IsNullOrEmpty(values.ToString()))
            {
                return Ok(values);
            }
            else return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetUrunList(int? id)
        {
            int NullOrEmpty = id ?? 0;
            if (NullOrEmpty != 0)
            {
                var values = rep.Urun!.Where(x => x.Id == id).FirstOrDefault();
                if (!string.IsNullOrEmpty(values!.ToString()))
                {
                    return Ok(values);
                }
                else return NotFound();
            }
            else return NotFound();
        }

        [HttpPost]
        public IActionResult PostUrun(Urun urun)
        {
            if (!string.IsNullOrEmpty(urun.ToString()))
            {
                rep.Urun!.Add(urun);
                rep.SaveChanges();
                return NoContent();
            }
            else return NotFound();
        }

        [HttpPut]
        public IActionResult PutUrun(Urun urun)
        {
            if (!string.IsNullOrEmpty(urun.ToString()))
            {
                var ReturnUrunValue = rep.Urun!.Where(x => x.Id == urun.Id).FirstOrDefault();
                if (!string.IsNullOrEmpty(ReturnUrunValue!.ToString()))
                {
                    ReturnUrunValue.SiparisUrunId = urun.SiparisUrunId;
                    ReturnUrunValue.UrunAdi = urun.UrunAdi;
                    ReturnUrunValue.StokMiktari = urun.StokMiktari;
                    ReturnUrunValue.BirimFiyati = urun.BirimFiyati;
                    ReturnUrunValue.KategoriId = urun.KategoriId;
                    rep.Urun!.Update(ReturnUrunValue);
                    rep.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteUrun(int? id)
        {
            int NullOrEmpty = id ?? 0;
            if (NullOrEmpty != 0)
            {
                var values = rep.Urun!.Where(x => x.Id == id).FirstOrDefault();
                if (!string.IsNullOrEmpty(values!.ToString()))
                {
                    rep.Urun!.Remove(values);
                    rep.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();
        }
    }

}