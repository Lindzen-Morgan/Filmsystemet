using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1App.Data; // Add the appropriate namespace for your context

namespace WebApplication1App.Data
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context; 

        public RatingRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            return rating;
        }

        public async Task<IEnumerable<Rating>> GetRatingsForPersonAsync(int personId)
        {
            return await _context.Ratings
                .Where(r => r.PersonId == personId)
                .ToListAsync();
        }
    }
}
