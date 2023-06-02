using BackEnd_Ecollama.Models;

namespace BackEnd_Ecollama.Repositories.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Productos>> GetAll();
    }
}
