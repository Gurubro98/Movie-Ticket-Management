using Movie_Ticket_Web_API.Models;

namespace Movie_Ticket_Web_API.Repository
{
    public interface IBookingRepository : IGenericRepository<BookingCart>
    {
        Task<IEnumerable<BookingCart>> GetByUserId(string userId);
        Task<BookingCart> GetByMovieId(int id);
        Task<BookingCart> GetByMovieandUserId(int id, string userId);
    }
}
