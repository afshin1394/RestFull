using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.CategoryRepository.ViewModels
{
    public class CategoryInput
    {
        

        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public int CategorySection { get; set; }

        public string CategoryDescription { get; set; }
        public string CategoryImage { get; set; }
    }
}
