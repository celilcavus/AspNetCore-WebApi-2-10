using Microsoft.AspNetCore.Mvc;
using Model.Contexts;
using Model.Entity;

namespace KargoTakipApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class ILController : ControllerBase
    {
        KargoTakipContext db = new KargoTakipContext();

        [HttpGet]
        public IActionResult GetIl()
        {
            var getIlValue = db.ils!.ToList();

            if (!string.IsNullOrEmpty(getIlValue.ToString()))
            {
                return Ok(getIlValue);
            }
            else
                return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult GetIl(int? id)
        {
            var getIlValue = db.ils!.FirstOrDefault(x => x.Id == id);

            if (!string.IsNullOrEmpty(getIlValue!.ToString()))
            {
                return Ok(getIlValue);
            }
            else
                return NotFound();
        }


        [HttpPost]
        public IActionResult PostIl(il il)
        {
            if (!string.IsNullOrEmpty(il.ToString()))
            {
                db.ils!.Add(il);
                db.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPut]
        public IActionResult PutIl(il il)
        {
            if (!string.IsNullOrEmpty(il.ToString()))
            {
                var returnUpdateil = db.ils!.Where(x => x.Id == il.Id).First();
                if (!string.IsNullOrEmpty(returnUpdateil.ToString()))
                {
                    returnUpdateil.IlAdi = il.IlAdi;
                    db.ils!.Update(returnUpdateil);
                    db.SaveChanges();
                    return NoContent();
                }
                else return NotFound();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteIl(int? id)
        {

            if (!string.IsNullOrEmpty(id.ToString()))
            {
                var getnDeleteValue = db.ils!.Find(id);
                if (!string.IsNullOrEmpty(getnDeleteValue!.ToString()))
                {
                    db.ils.Remove(getnDeleteValue);
                    db.SaveChanges();
                    
                    return NoContent();
                }
                else return NotFound();
            }
            else return NotFound();
        }
    }
}