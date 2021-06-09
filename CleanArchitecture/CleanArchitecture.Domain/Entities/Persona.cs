using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public class Persona
    {
        public Persona()
        {
            RichiesteInCorso = new List<RichiesteAmicizia>();
            Amici = new List<Persona>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public List<RichiesteAmicizia> RichiesteInCorso { get; set; }
        public List<Persona> Amici { get; set; }
        public Address Address {get;set;}
    }
    public class Address
    {
        public string Citta { get; set; }
        public string Indirizzo { get;set;}
    }
    public class RichiesteAmicizia
    {
        public int Id { get; set; }
        public DateTime DataRichiesta { get; set; }
        public Persona Amico { get; set; }
    }
}