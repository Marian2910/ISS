using TeatruBE.Models;
using TeatruBE.Repositories;

namespace TeatruBE.Services
{
    public class SpectacolService : ISpectacolService
    {
        private readonly ISpectacolRepository _repository;

        public SpectacolService(ISpectacolRepository repository)
        {
            _repository = repository;
        }

        public Spectacol GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting spectacol by id: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<Spectacol> GetAllSpectacols()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all spectacols: {ex.Message}");
                throw;
            }
        }

        
        public void AddSpectacol(Spectacol spectacol)
        {
            try
            {
                _repository.Add(spectacol);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding spectacol: {ex.Message}");
                throw;
            }
        }

        public void UpdateSpectacol(Spectacol spectacol)
        {
            try
            {
                _repository.Update(spectacol);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating spectacol: {ex.Message}");
                throw;
            }
        }

        public void DeleteSpectacol(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting spectacol: {ex.Message}");
                throw;
            }
        }
    }
}