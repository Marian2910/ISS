using System.Collections.Generic;
using TeatruBE.Models;

namespace TeatruBE.Repositories
{
    public interface ISpectacolRepository
    {
        IEnumerable<Spectacol> GetAll();
        Spectacol GetById(int id);
        void Add(Spectacol spectacol);
        void Update(Spectacol spectacol);
        void Delete(int id);
    }
}