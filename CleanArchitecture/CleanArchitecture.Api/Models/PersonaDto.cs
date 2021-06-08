using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Api.Models
{
    public class PersonaDto
    {
        public int Id { get; set; }
        public string Nome {get;set;}
        public string Cognome {get;set;}
        public List<PersonaDto> Amici {get;set;}
        public List<RichiesteAmiciziaDto> RichiesteInCorso {get;set;}
    }

    public class RichiesteAmiciziaDto
    {
        public PersonaDto PotenzialeAmico { get; set; }
        public DateTime DataRichiestaAmicizia { get; set; }
    }
}
