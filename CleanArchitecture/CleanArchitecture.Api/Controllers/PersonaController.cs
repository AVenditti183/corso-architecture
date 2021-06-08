using CleanArchitecture.Api.Models;
using CleanArchitecture.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Get([FromRoute] string citta)
        {
            var persone= service.Search(citta);

            var data = persone.Select( o=> 
            new PersonaDto
            {
                Id = o.Id,
                Cognome = o.Cognome,
                Nome = o.Nome,
                Amici = new List<PersonaDto>(),
                RichiesteInCorso = new List<RichiesteAmiciziaDto>()
            });
            return Ok(persone);
        }
    }
}
