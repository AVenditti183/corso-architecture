using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public List<RichiesteAmicizia> RichiesteInCorso { get; set; }
        public List<Persona> Amici { get; set; }
        public Address address {get;set;}
    }

    public class Address
    {
        public string Citta { get; set; }
        public string Indirizzo { get;set;}
    }
}