using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.QuestionRepository.ViewModels.QuestionViewModel.Inputs
{
    public class QuestionInput
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string QuestionStr { get; set; }

    }
}
