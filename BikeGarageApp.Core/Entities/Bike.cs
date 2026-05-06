using System.ComponentModel.DataAnnotations;

namespace BikeGarageApp.Core.Entities
{
    public enum BikeModel
    {
        MTB,
        Road,
        Gravel,
        Cyclocross,
        TimeTrial
    }

    public enum Tier
    {
        Shimano105,
        Ultegra,
        DuraAce
    }

    public class Bike
    {
        public int Id { get; set; }
        public Guid SerialNumber { get; set; } = Guid.NewGuid();
        public required string ModelName { get; set; }

        public BikeModel Model { get; set; }
        public Tier Tier { get; set; }
        public int Year { get; set; }
        
        [Range(44, 61)]
        public int Size { get; set; }
        public decimal Milage { get; set; }

        public string URLPicture { get; set; } = string.Empty;
    }
}
