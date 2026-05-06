using BikeGarageApp.Core.Entities;

namespace BikeGarageApp.Core.Interfaces
{
    public interface IBikeRepository
    {
        Task<IEnumerable<Bike>> GetAllBikesAsync(CancellationToken cancellationToken = default);
        Task<Bike?> GetBikeByIdAsync(int id, CancellationToken cancellationToken = default);
        Task AddAsync(Bike bike, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Bike bike, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
