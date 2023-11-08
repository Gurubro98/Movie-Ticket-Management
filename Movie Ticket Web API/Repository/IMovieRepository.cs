using Movie_Ticket_Web_API.Models;

namespace Movie_Ticket_Web_API.Repository
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetByAdmineId(string id);
    }
}
