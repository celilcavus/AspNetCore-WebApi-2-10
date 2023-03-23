using Microsoft.AspNetCore.Mvc;
using Model.Contexts;
using Model.Entity;

namespace KargoTakipApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class FaturaController : ControllerBase
    {
        KargoTakipContext db = new KargoTakipContext();
        [HttpGet]
        public IActionResult GetFatura()
        {
            var values = db.Faturas!.ToList();
            if (values != null)
            {
                return Ok(values);
            }
            else
                return NotFound();

        }
        [HttpGet("{id}")]
        public IActionResult GetFatura(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var returnFaturaValues = db.Faturas!.FirstOrDefault(x => x.Id == id);
                if (returnFaturaValues != null)
                {
                    return Ok(returnFaturaValues);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPost]
        public IActionResult PostFatura(Fatura fatura)
        {
            if (fatura != null)
            {
                db.Faturas!.Add(fatura);
                db.SaveChanges();
                return NoContent();
            }
            else
                return NotFound();
        }
        [HttpPut]
        public IActionResult PutFatura(Fatura? fatura)
        {
            if (fatura!.Id == 0)
            {
                return NotFound();
            }
            else
            {
                var UpdateFatura = db.Faturas!.Where(x => x.Id == fatura.Id).First();
                if (!string.IsNullOrEmpty(UpdateFatura.ToString()))
                {
                    UpdateFatura.SiporisId = fatura.SiporisId;
                    UpdateFatura.FaturaTarihi = fatura.FaturaTarihi;
                    db.Faturas!.Update(UpdateFatura);
                    db.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFatura(int? id)
        {
            if (id != null)
            {
                var DeleteFaturaValue = db.Faturas!.Where(x => x.Id == id).FirstOrDefault();
                if (DeleteFaturaValue != null)
                {
                    db.Faturas!.Remove(DeleteFaturaValue);
                    db.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}