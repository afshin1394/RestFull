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

        /*public int? Id { get; set; }
        public int? CategoryID { get; set; }
        public string CategoryName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? QuestionGuid { get; set; } = Guid.NewGuid();
        public string QuestionStr { get; set; }*/
    }
}
