using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Dobavljac
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Polje obavezno")]
        [Display(Name="Naziv dobavljača")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Polje obavezno")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Polje obavezno")]
        public string Telefon { get; set; }
    }
}
