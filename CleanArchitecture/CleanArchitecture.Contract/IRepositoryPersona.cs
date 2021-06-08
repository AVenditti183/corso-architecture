using CleanArchitecture.Domain.Entities;
using System.Linq;

namespace CleanArchitecture.Contract
{
    public interface IRepositoryPersona
    {
        Persona Get(int Id);
        IQueryable<Persona> Search();
        int Insert(Persona persona);
        void Update(Persona persona, int id);
        void Delete(int id);
    }
}
