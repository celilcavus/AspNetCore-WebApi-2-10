using Microsoft.AspNetCore.Mvc;
using Model.Contexts;
using Model.Entity;

namespace KargoTakipApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class KategoriController : ControllerBase
    {
        KargoTakipContext rep = new KargoTakipContext();
        [HttpGet]
        public IActionResult GetKategroiList()
        {
            var GetKaregori = rep.kategoris!.ToList();
            if (!string.IsNullOrEmpty(GetKaregori.ToString()))
            {
                return Ok(GetKaregori);
            }
            else return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult GetKategroiList(int? id)
        {
            int value = id ?? 0;
            if (value != 0)
            {
                var GetKaregori = rep.kategoris!.Where(x => x.Id == id).First();
                if (!string.IsNullOrEmpty(GetKaregori.ToString()))
                {
                    return Ok(GetKaregori);
                }
                else return NotFound();
            }
            else return NotFound();
        }


        [HttpPost]
        public IActionResult PostKategori(Kategori kategori)
        {
            if (!string.IsNullOrEmpty(kategori.ToString()))
            {
                rep.kategoris!.Add(kategori);
                rep.SaveChanges();
                return NoContent();
            }
            else return NotFound();
        }

        [HttpPut]
        public IActionResult PutKategori(Kategori kategori)
        {
            var GetKategori = rep.kategoris!.Where(x => x.Id == kategori.Id).First();
            if (!string.IsNullOrEmpty(GetKategori.ToString()))
            {

                GetKategori.KategoriAdi = kategori.KategoriAdi;
                GetKategori.UrunId = kategori.UrunId;

                rep.kategoris!.Update(GetKategori);
                rep.SaveChanges();
                return NoContent();
            }
            else return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteKategori(int? id)
        {
            int NullOrEmpty = id ?? 0;
            if (!string.IsNullOrEmpty(NullOrEmpty.ToString()))
            {
                var GetKategori = rep.kategoris!.Where(x => x.Id == id).First();
                if (!string.IsNullOrEmpty(GetKategori.ToString()))
                {
                    rep.kategoris!.Remove(GetKategori);
                    rep.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();
        }
    }
}