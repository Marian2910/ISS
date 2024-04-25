using TeatruBE.Models;

namespace TeatruBE.Services
{
    public interface ISpectacolService
    {
        IEnumerable<Spectacol> GetAllSpectacols();
        Spectacol GetById(int id);
        void AddSpectacol(Spectacol spectacol);
        void UpdateSpectacol(Spectacol spectacol);
        void DeleteSpectacol(int id);
    }
}