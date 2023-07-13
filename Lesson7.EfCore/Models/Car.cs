namespace Lesson7.EfCore.Models
{
    public class Car : BaseEntity
    {
        public string Vendor { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Number { get; set; } = null!;
        public Driver? Driver { get; set; }
    }
}
