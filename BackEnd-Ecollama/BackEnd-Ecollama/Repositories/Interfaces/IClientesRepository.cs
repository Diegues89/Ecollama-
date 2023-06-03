using BackEnd_Ecollama.Models;

namespace BackEnd_Ecollama.Repositories.Interfaces
{
    public interface IClientesRepository
    {
        Task<IEnumerable<Clientes>> GetAll();
    }
}
