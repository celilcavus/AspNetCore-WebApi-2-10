using Microsoft.AspNetCore.Mvc;
using Model.Contexts;
using Model.Entity;

namespace KargoTakipApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class KargoFirmasiController : ControllerBase
    {
        KargoTakipContext rep = new KargoTakipContext();
        [HttpGet]
        public IActionResult GetKargoFirmasiList()
        {
            var getKargoFirmasi = rep.kargoFirmasis!.ToList();
            if (!string.IsNullOrEmpty(getKargoFirmasi.ToString()))
            {
                return Ok(getKargoFirmasi);
            }
            else return NotFound();

        }


        [HttpGet("{id}")]
        public IActionResult GetKargoFirmasiList(int? id)
        {
            var getKargoFirmasi = rep.kargoFirmasis!.FirstOrDefault(x => x.Id == id);
            if (!string.IsNullOrEmpty(getKargoFirmasi!.ToString()))
            {
                return Ok(getKargoFirmasi);
            }
            else return NotFound();
        }
        [HttpPost]
        public IActionResult PostKargoFirmasi(KargoFirmasi kargoFirmasi)
        {
            if (!string.IsNullOrEmpty(kargoFirmasi.ToString()))
            {
                rep.kargoFirmasis!.Add(kargoFirmasi);
                rep.SaveChanges();
                return NoContent();
            }
            else return NotFound();
        }

        [HttpPut]
        public IActionResult PutKargoFirmasi(KargoFirmasi kargoFirmasi)
        {
            var returnGetKargoFirmasi = rep.kargoFirmasis!.Where(x => x.Id == kargoFirmasi.Id).FirstOrDefault();
            if (!string.IsNullOrEmpty(returnGetKargoFirmasi!.ToString()))
            {
                returnGetKargoFirmasi.KargoAd = kargoFirmasi.KargoAd;
                returnGetKargoFirmasi.SiparisId = kargoFirmasi.SiparisId;
                returnGetKargoFirmasi.Adres = kargoFirmasi.Adres;
                returnGetKargoFirmasi.Temsilci = kargoFirmasi.Temsilci;

                rep.kargoFirmasis!.Update(returnGetKargoFirmasi);
                rep.SaveChanges();

                return NoContent();
            }
            else return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteKargoFirmasi(int? id)
        {
            // Id burda 0 dışında farklı bir null tipi dönerse ife girmiyiceğini düşünerek bu şekil bir yöntem yaptım 
            //eğer id null ise id değerine 0 atnıcak.
            var value = id ?? 0;
            if (value != 0)
            {
                var getKargoFirmasi = rep.kargoFirmasis!.FirstOrDefault(x => x.Id == id);
                if (!string.IsNullOrEmpty(getKargoFirmasi!.ToString()))
                {
                    rep.kargoFirmasis!.Remove(getKargoFirmasi);
                    rep.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();
        }


    }
}