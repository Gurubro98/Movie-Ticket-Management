using Microsoft.EntityFrameworkCore;
using Movie_Ticket_Web_API.Context;
using Movie_Ticket_Web_API.Models;

namespace Movie_Ticket_Web_API.Repository
{
    public class BookingRepository : GenericRepository<BookingCart>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<BookingCart>> GetByUserId(string userId)
        {
            return await table.Where(u => u.UserId == userId).ToListAsync();
        }

        public async Task<BookingCart> GetByMovieId(int id)
        {
            return await table.FirstOrDefaultAsync(u => u.MovieId == id);
        }
        public async Task<BookingCart> GetByMovieandUserId(int id,string userId)
        {
            return await table.FirstOrDefaultAsync(u => u.MovieId == id && u.UserId == userId);
        }

    }
}
