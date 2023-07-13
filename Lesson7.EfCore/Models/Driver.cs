namespace Lesson7.EfCore.Models
{
    public class Driver : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
        public bool Lisence { get; set; }
        public Car? Car { get; set; }
        public int? CarId { get; set; }
    }
}