using System.ComponentModel.DataAnnotations;

namespace BuffTeksApartment
{
    public class Resident
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? UnitNumber { get; set; }
    }
}
