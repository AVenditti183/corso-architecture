using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Business
{
    public interface IPersonService
    {
        List<Persona> Search(string citta);
        List<Persona> MieiAmici(int personaId);
        void RichiediAmicizia(int personaRichiedenteId, int amicoPotenzialeId);
        void RichiestaAmiciziaAccetta(int amicoId, int personaRichiedenteId);
        void RichiestaAmiciziaRifiutata(int amicoId, int personaRichiedenteId);
    }
}
