using Microsoft.AspNetCore.Mvc;
using Model.Contexts;
using Model.Entity;

namespace KargoTakipApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class SiparisUrunController : ControllerBase
    {
        KargoTakipContext rep = new KargoTakipContext();
        [HttpGet]
        public IActionResult GetSiparisUrunList()
        {
            var values = rep.SiparisUruns!.ToList();
            if (!string.IsNullOrEmpty(values.ToString()))
            {
                return Ok(values);
            }
            else return NotFound();
        }
        [HttpGet("{id}")]
        public IActionResult GetSiparisUrunList(int? id)
        {
            int NullOrEmpty = id ?? 0;
            if (NullOrEmpty != 0)
            {
                var values = rep.SiparisUruns!.Where(x => x.Id == id).FirstOrDefault();
                if (!string.IsNullOrEmpty(values!.ToString()))
                {
                    return Ok(values);
                }
                else return NotFound();
            }
            else return NotFound();
        }
        [HttpPost]
        public IActionResult PostSiparisUrun(SiparisUrun siparisUrun)
        {
            if (!string.IsNullOrEmpty(siparisUrun.ToString()))
            {
                rep.SiparisUruns!.Add(siparisUrun);
                rep.SaveChanges();
                return NotFound();
            }
            else return NotFound();
        }

        [HttpPut]
        public IActionResult PutSiparisUrun(SiparisUrun siparisUrun)
        {
            if (!string.IsNullOrEmpty(siparisUrun.ToString()))
            {
                var ReturnSiparisUrunValue = rep.SiparisUruns!.Where(x => x.Id == siparisUrun.Id).FirstOrDefault();
                if (!string.IsNullOrEmpty(ReturnSiparisUrunValue!.ToString()))
                {
                    ReturnSiparisUrunValue.SiparisId = siparisUrun.SiparisId;
                    ReturnSiparisUrunValue.UrunId = siparisUrun.UrunId;
                    ReturnSiparisUrunValue.BirimFiyati = siparisUrun.BirimFiyati;
                    ReturnSiparisUrunValue.Miktari = siparisUrun.Miktari;
                    rep.SiparisUruns!.Update(ReturnSiparisUrunValue);
                    rep.SaveChanges();
                    return NotFound();
                }
                else return NotFound();
            }
            else return NotFound();
        }

        public IActionResult DeleteSiparisUrun(int? id)
        {
            int NullOrEmpty = id ?? 0;
            if (NullOrEmpty != 0)
            {
                var values = rep.SiparisUruns!.Where(x => x.Id == id).FirstOrDefault();
                if (!string.IsNullOrEmpty(values!.ToString()))
                {
                    rep.SiparisUruns!.Remove(values);
                    rep.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();
        }
    }
}