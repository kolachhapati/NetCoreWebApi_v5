using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi_v5.Models
{
    public class CountryDTO 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:50)]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 3)]
        public string ShortName { get; set; }
    }
}
