using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace programmingwebapp.Models
{
    public class File
    {
        public Guid FileId { get; set; }

        [Required]
        public Guid ProgramId { get; set; }

        [ForeignKey("ProgramId")]
        public virtual Program Program { get; set; }

        [Required]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string FileContent { get; set; }
    }
}
