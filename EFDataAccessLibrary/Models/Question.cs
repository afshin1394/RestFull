using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
   public class Question
    {
        public int Id { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid QuestionGuid { get; set; } = Guid.NewGuid();
        public string QuestionStr { get; set; }
    }
}

