using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNarudzbe.Models
{
    public class ProizvodDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Polje obavezno")]
        [Display(Name = "Naziv proizvoda")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Polje obavezno")]
        [Display(Name = "Cijena u KN")]
        [DataType(DataType.Currency)]
        public double Cijena { get; set; }     // kod unosa ide bez separatora" 
        [Required(ErrorMessage = "Polje obavezno")]
        [ForeignKey("Dobavljac")] //Veza Dobavljac_ID - Dobavljac.ID
        public int Dobavljac_ID { get; set; }
        public virtual Dobavljac Dobavljac { get; set; }
        public virtual ICollection<Narudzbe> Narudzbe { get; set; }
    }
}
