using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.BottleRepository.ViewModels
{
    public class BottleInput
    {
        public Guid BottleGuid { get; set; }
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int IsPurchased { get; set; }
    }
}
