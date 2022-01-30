using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Bottle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BottleGuid { get; set; } = Guid.NewGuid();

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int IsPurchased  { get; set; }

    }
}
