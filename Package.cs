using System;
using System.ComponentModel.DataAnnotations;

namespace BuffTeksApartment
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public string ResidentName { get; set; } = string.Empty; 
        public string PostalService { get; set; } = string.Empty; 
        public DateTime DeliveryDate { get; set; }
        public bool IsPickedUp { get; set; }
    }
}