using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models.QuestionViewModel
{
    public class Question
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string QuestionStr { get; set; }
    }
}
