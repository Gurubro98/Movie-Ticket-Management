using Microsoft.EntityFrameworkCore;
using Movie_Ticket_Web_API.Context;
using Movie_Ticket_Web_API.Models;

namespace Movie_Ticket_Web_API.Repository
{
    public class UserRepository : GenericRepository<Movie>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Tuple<IEnumerable<Movie>, int>> GetAllData(int pageNumber = 1, string searchTxt = "", string sortOrder = "")
        {
            int pageSize = 10;
            var totalCount = await table.CountAsync();
            var totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);
            Tuple<IEnumerable<Movie>, int> data;
            if (string.IsNullOrEmpty(searchTxt))
            {
                searchTxt = "";
                var result = await table.Where(u => u.Name.ToLower().Contains(searchTxt.ToLower())).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                switch (sortOrder)
                {
                    case "name_desc":
                        result = result.OrderByDescending(s => s.Name).ToList();
                        break;
                    case "Date":
                        result = result.OrderBy(s => s.Date).ToList();
                        break;
                    case "date_desc":
                        result = result.OrderByDescending(s => s.Date).ToList();
                        break;
                    default:
                        result = result.OrderBy(s => s.Name).ToList();
                        break;
                }

                data = new Tuple<IEnumerable<Movie>, int>(result, totalPage);
            }
            else
            {
                var result = await table.Where(u => u.Name.ToLower().Contains(searchTxt.ToLower())).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                switch (sortOrder)
                {
                    case "name_desc":
                        result = result.OrderByDescending(s => s.Name).ToList();
                        break;
                    case "Date":
                        result = result.OrderBy(s => s.Date).ToList();
                        break;
                    case "date_desc":
                        result = result.OrderByDescending(s => s.Date).ToList();
                        break;
                    default:
                        result = result.OrderBy(s => s.Name).ToList();
                        break;
                }
                totalCount = result.Count;
                totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);
                data = new Tuple<IEnumerable<Movie>, int>(result, totalPage);
            }
            

            return data;
        }
    }
}
