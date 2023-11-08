using Movie_Ticket_Web_API.Models;

namespace Movie_Ticket_Web_API.Repository
{
    public interface IUserRepository : IGenericRepository<Movie>
    {
        Task<Tuple<IEnumerable<Movie>, int>> GetAllData(int pageNumber = 1, string searchTxt = "", string sortOrder="");
    }
}
