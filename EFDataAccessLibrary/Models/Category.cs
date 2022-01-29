using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CategoryGuid { get; set; } = Guid.NewGuid();

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public int CategorySection { get; set; }
      
        public string CategoryDescription { get; set; }

        public string CategoryImage { get; set; }

    }
}
