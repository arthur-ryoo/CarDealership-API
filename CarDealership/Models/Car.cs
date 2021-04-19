using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public bool HasSunroof { get; set; }
        [Required]
        public bool IsFourWheelDrive { get; set; }
        [Required]
        public bool HasLowMiles { get; set; }
        [Required]
        public bool HasPowerWindows { get; set; }
        [Required]
        public bool HasNavigation { get; set; }
        [Required]
        public bool HasHeatedSeats { get; set; }
    }
}
