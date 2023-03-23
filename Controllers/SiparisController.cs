using Microsoft.AspNetCore.Mvc;
using Model.Contexts;
using Model.Entity;

namespace KargoTakipApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class SiparisController : ControllerBase
    {
        KargoTakipContext rep = new KargoTakipContext();
        [HttpGet]
        public IActionResult GetSiparisList()
        {
            var getSiparisValues = rep.Siparis!.ToList();
            if (!string.IsNullOrEmpty(getSiparisValues.ToString()))
            {
                return Ok(getSiparisValues);
            }
            else return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetSiparisList(int? id)
        {
            int NullOrEmpty = id ?? 0;
            if (NullOrEmpty != 0)
            {
                var getSiparisValues = rep.Siparis!.Where(x => x.Id == id).FirstOrDefault();
                if (!string.IsNullOrEmpty(getSiparisValues!.ToString()))
                {
                    return Ok(getSiparisValues);
                }
                else return NotFound();
            }
            else return NotFound();
        }
        [HttpPost]
        public IActionResult PostSiparis(Siparis siparis)
        {
            if (!string.IsNullOrEmpty(siparis.ToString()))
            {
                rep.Siparis!.Add(siparis);
                rep.SaveChanges();
                return NoContent();
            }
            else return NotFound();
        }
        [HttpPut]
        public IActionResult PutSiparis(Siparis siparis)
        {
            var returnValue = rep.Siparis!.Where(x => x.Id == siparis.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(returnValue!.ToString()))
            {
                //  SiparisTarihi, ToplamTutar, KargoFirmasiId, FaturaId, MusteriId, SatisTemsilcisiId, SiparisUrunId
                returnValue.SiparisTarihi = siparis.SiparisTarihi;
                returnValue.ToplamTutar = siparis.ToplamTutar;
                returnValue.KargoFirmasiId = siparis.KargoFirmasiId;
                returnValue.FaturaId = siparis.FaturaId;
                returnValue.MusteriId = siparis.MusteriId;
                returnValue.SatisTemsilcisiId = siparis.SatisTemsilcisiId;
                returnValue.SiparisUrunId = siparis.SiparisUrunId;
                rep.Siparis!.Update(returnValue);
                rep.SaveChanges();
                return NoContent();
            }
            else return NotFound();
        }
    }
}