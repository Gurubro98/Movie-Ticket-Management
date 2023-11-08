using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movie_Ticket_Web_API.Context;
using Movie_Ticket_Web_API.Models;

namespace Movie_Ticket_Web_API.Repository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Movie>> GetByAdmineId(string id)
        {
            return await table.Where(u => u.UserId == id).ToListAsync();
            //int pageSize = 2;
            //var totalCount = await table.Where(x => x.UserId == id).CountAsync();
            //var totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);
            //Tuple<IEnumerable<Movie>, int> data;
            //if (string.IsNullOrEmpty(searchTxt))
            //{
            //    searchTxt = "";
            //    var result = await table.Where(x => x.UserId == id).Where(u => u.Name.ToLower().Contains(searchTxt.ToLower())).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            //    data = new Tuple<IEnumerable<Movie>, int>(result, totalPage);
            //}
            //else
            //{
            //    var result = await table.Where(x => x.UserId == id).Where(u => u.Title.ToLower().Contains(searchTxt.ToLower()) || u.ServiceType.ServiceName.ToLower().Contains(searchTxt.ToLower())).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            //    totalCount = result.Count;
            //    totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);
            //    data = new Tuple<IEnumerable<Movie>, int>(result, totalPage);
            //}


            //return data;

        }
    }
}
