using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi_v5.Models
{
    public class CreateHotelDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        public int CountryId { get; set; }
    }

    public class HotelDTO : CreateHotelDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }
}
