using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models.DareViewModel
{
    public class Dare
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string DareStr { get; set; }
    }
}
