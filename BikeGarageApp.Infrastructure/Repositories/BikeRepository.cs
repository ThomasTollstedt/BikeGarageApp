using BikeGarageApp.Core.Entities;
using BikeGarageApp.Core.Interfaces;
using BikeGarageApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace BikeGarageApp.Infrastructure.Repositories
{
    public class BikeRepository(BikeGarageDbContext context) : IBikeRepository
    {

        public async Task AddAsync(Bike bike, CancellationToken cancellationToken = default)
        {

            var newBike = await context.Bikes.AddAsync(bike, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var bike = await context.Bikes.FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
            if (bike == null)
            {
                return false;
            }

            context.Bikes.Remove(bike);
            await context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<IEnumerable<Bike>> GetAllBikesAsync(CancellationToken cancellationToken = default)
        {
            return await context.Bikes
                .AsNoTracking()
                .ToListAsync(cancellationToken);

        }

        public async Task<Bike?> GetBikeByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await context.Bikes
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

        }

        public async Task<bool> UpdateAsync(Bike bike, CancellationToken cancellationToken = default)
        {
            var updateBike = await context.Bikes
                .FirstOrDefaultAsync(b => b.Id == bike.Id, cancellationToken);
            if (updateBike == null)
            {
                return false;
            }

            updateBike.ModelName = bike.ModelName;
            updateBike.Model = bike.Model;
            updateBike.Milage = bike.Milage;
            updateBike.Size = bike.Size;
            updateBike.Tier = bike.Tier;
            updateBike.URLPicture = bike.URLPicture;
            updateBike.Year = bike.Year;

            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
