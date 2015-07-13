using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programmingwebapp.Models
{
    public class Program
    {
        public Guid ProgramId { get; set; }

        [Required]
        [Display(Name = "Language")]
        public Language Language { get; set; }

        [Required]
        [Display(Name = "Program Name")]
        public string ProgramName { get; set; }

        public virtual List<File> Files { get; set; }

        [Display(Name = "Program, Language")]
        public string DisplayName { get; set; }
    }
}
