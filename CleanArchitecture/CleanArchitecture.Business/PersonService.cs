using CleanArchitecture.Contract;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Business
{

    public class PersonService : IPersonService
    {
        private readonly IRepositoryPersona repository;

        public PersonService(IRepositoryPersona repository)
        {
            this.repository = repository;
        }

        public List<Persona> MieiAmici(int personaId)
        {
            var persona = repository.Get(personaId);

            return persona.Amici;
        }

        public void RichiediAmicizia(int personaRichiedenteId, int amicoPotenzialeId)
        {
            var amicoPotenziale = repository.Get(amicoPotenzialeId);
            var personaRichiedente = repository.Get(personaRichiedenteId);

            var nuovaRichiestaAmicizia = new RichiesteAmicizia
            {
                Amico = personaRichiedente,
                DataRichiesta = DateTime.Now,
            };

            amicoPotenziale.RichiesteInCorso.Add(nuovaRichiestaAmicizia);

            repository.Update(amicoPotenziale, amicoPotenzialeId);
        }
        public void RichiestaAmiciziaAccetta(int amicoId, int personaRichiedenteId)
        {
            var amico = repository.Get(amicoId);
            var nuovoAmico = repository.Get(personaRichiedenteId);

            var richiestaInCorsoDaCancellare = amico.RichiesteInCorso.FirstOrDefault(o => o.Amico.Id == personaRichiedenteId);
            if (richiestaInCorsoDaCancellare is null)
                return;

            amico.Amici.Add(nuovoAmico);

            amico.RichiesteInCorso.Remove(richiestaInCorsoDaCancellare);

            repository.Update(amico, amicoId);
        }
        public void RichiestaAmiciziaRifiutata(int amicoId, int personaRichiedenteId)
        {
            var amico = repository.Get(amicoId);
            var nuovoAmico = repository.Get(personaRichiedenteId);

            var richiestaInCorsoDaCancellare = amico.RichiesteInCorso.FirstOrDefault(o => o.Amico.Id == personaRichiedenteId);
            if (richiestaInCorsoDaCancellare is null)
                return;

            amico.RichiesteInCorso.Remove(richiestaInCorsoDaCancellare);

            repository.Update(amico, amicoId);
        }

        public List<Persona> Search(string citta)
        {
            return repository.Search().Where(o => o.Address.Citta == citta).ToList();
        }

    }
}
