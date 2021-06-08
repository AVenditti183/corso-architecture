using System;

namespace CleanArchitecture.Domain.Entities
{
    public class RichiesteAmicizia
    {
        public int Id { get; set; }
        public DateTime DataRichiesta { get; set; }
        public Persona Amico { get; set; }
    }
}