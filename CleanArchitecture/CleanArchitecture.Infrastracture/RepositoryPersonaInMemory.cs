using CleanArchitecture.Contract;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Infrastracture
{
    public class RepositoryPersonaInMemory : IRepositoryPersona
    {
        private List<Persona> persone;
        public RepositoryPersonaInMemory()
        {
            persone = new List<Persona>()
            {
                 new Persona
                 {
                     Id =1,
                     Nome ="Antonio",
                     Cognome ="Venditti",
                      Address = new Address
                      {
                          Citta ="Fondi",
                          Indirizzo ="casa"
                      },
                      Amici = new List<Persona>(),
                      RichiesteInCorso = new List<RichiesteAmicizia>()
                 },
                 new Persona
                 {
                     Id =2,
                     Nome ="Pietro",
                     Cognome ="Savastano",
                      Address = new Address
                      {
                          Citta ="Napoli",
                          Indirizzo ="non si sa"
                      },
                      Amici = new List<Persona>(),
                      RichiesteInCorso = new List<RichiesteAmicizia>()
                 }
            };
        }

        public void Delete(int id)
        {
            var personaDaCancellare = persone.FirstOrDefault( o => o.Id == id);
            if (personaDaCancellare is null)
                return;

           persone.Remove(personaDaCancellare);
        }
        public Persona Get(int Id)
        {
           return persone.FirstOrDefault( o => o.Id == Id);
        }
        public int Insert(Persona persona)
        {
            var lastId = persone.Max( o=> o.Id);
            persona.Id = lastId+1;
            persone.Add(persona);

            return persona.Id;
        }
        public IQueryable<Persona> Search()
        {
           return persone.AsQueryable();
        }
        public void Update(Persona persona, int id)
        {
            this.Delete(id);
            persone.Add(persona);
        }
    }
}
