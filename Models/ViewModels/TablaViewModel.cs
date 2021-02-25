using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFInal2021Beta.Models.ViewModels
{
    public class TablaViewModel
    {

        public int ProgramaId { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        [StringLength(50)]
        public string Categoria { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Alta")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Alta { get; set; }



    }
}