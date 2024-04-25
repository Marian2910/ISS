
using TeatruBE.Models;

namespace TeatruBE.Repositories
{
    public class SpectacolRepository : ISpectacolRepository
    {
        private readonly TeatruContext _context;

        public SpectacolRepository(TeatruContext context)
        {
            _context = context;
        }

        public IEnumerable<Spectacol> GetAll()
        {
            return _context.Spectacols.ToList();
        }

        public Spectacol GetById(int id)
        {
            return _context.Spectacols.FirstOrDefault(s => s.SpectacolId == id);
        }

        public void Add(Spectacol spectacol)
        {
            _context.Spectacols.Add(spectacol);
            _context.SaveChanges();
        }

        public void Update(Spectacol spectacol)
        {
            _context.Spectacols.Update(spectacol);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var spectacol = GetById(id);
            if (spectacol != null)
            {
                _context.Spectacols.Remove(spectacol);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Spectacol not found");
            }
        }
    }
}