namespace WebApplication1.Data
{
    public interface IRatingRepository
    {
        Task<Rating> AddRatingAsync(Rating rating);
        Task<IEnumerable<Rating>> GetRatingsForPersonAsync(int personId);
    }
}
