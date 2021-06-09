using CleanArchitecture.Api.Models;
using CleanArchitecture.Business;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonService service;

        public PersonaController(IPersonService service)
        {
            this.service = service;
        }


        [HttpGet("amici/{citta}")]
        public IActionResult Search([FromRoute] string citta)
        {
            var persone = service.Search(citta);

            var data = persone.Select(o =>
           new PersonaDto
           {
               Id = o.Id,
               Cognome = o.Cognome,
               Nome = o.Nome
           });
            return Ok(data);
        }

        [HttpGet("{id}/amici")]
        public IActionResult GetAmici([FromRoute] int id)
        {
            var amici = service.MieiAmici(id);

            var data = amici.Select(o =>
           new PersonaDto
           {
               Id = o.Id,
               Cognome = o.Cognome,
               Nome = o.Nome
           });
            return Ok(data);
        }

        [HttpGet("{id}/richiestaamicizia/{nuovaPersonaId}")]
        public IActionResult RichiestaAmicizia([FromRoute] int id, int nuovaPersonaId)
        {
            service.RichiediAmicizia(id, nuovaPersonaId);

            return Ok();
        }

        [HttpGet("{id}/richiestaamiciziaAccetta/{nuovaPersonaId}")]
        public IActionResult RichiestaAmiciziaAccetta([FromRoute] int id, int nuovaPersonaId)
        {
            service.RichiestaAmiciziaAccetta(id, nuovaPersonaId);

            return Ok();
        }

        [HttpGet("{id}/richiestaamiciziaNegata/{nuovaPersonaId}")]
        public IActionResult RichiestaAmiciziaNEgata([FromRoute] int id, int nuovaPersonaId)
        {
            service.RichiestaAmiciziaRifiutata(id, nuovaPersonaId);

            return Ok();
        }

        [HttpGet("{id}/richiestediamiciziaincorso")]
        public IActionResult GetRichiestaAmicizia([FromRoute] int id)
        {
            var persona = service.Get(id);

            var data = persona.RichiesteInCorso.Select(o =>
           new RichiesteAmiciziaDto
           {
               DataRichiestaAmicizia = o.DataRichiesta,
               PotenzialeAmico = new PersonaDto
               {
                   Id = o.Amico.Id,
                   Cognome = o.Amico.Cognome,
                   Nome = o.Amico.Nome
               }
           });
            return Ok(data);
        }
    }
}
