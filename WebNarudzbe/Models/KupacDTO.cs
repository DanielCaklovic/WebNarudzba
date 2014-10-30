using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;

namespace WebNarudzbe.Models
{
    public class KupacDTO
    {

        public int ID { get; set; }
        [Required(ErrorMessage = "Polje obavezno")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Polje obavezno")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Polje obavezno")]
        public string Adresa { get; set; }
        [Required(ErrorMessage = "Polje obavezno")]
        public string Telefon { get; set; }


        public virtual ICollection<Narudzbe> Narudzbe { get; set; }
        [Display(Name = "Ime i prezime")]
        public string Ime_prezime { get { return Ime + " " + Prezime; } }
    }
}
