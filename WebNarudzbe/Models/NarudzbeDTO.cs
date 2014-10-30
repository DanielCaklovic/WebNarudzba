using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;

namespace WebNarudzbe.Models
{
    public class NarudzbeDTO
    {

        [Key] //PK
        [Column(Order = 0)] // ORDER MULTIPLE PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Autoincrement
        [Display(Name = "ID narudžbe")]
        [Required]
        public int NarudzbeID { get; set; }
        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Polje obavezno")]
        public int ProizvodID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "Polje obavezno")]
        public int KupacID { get; set; }

        public virtual Proizvod Proizvod { get; set; }
        public virtual Kupac Kupac { get; set; }
    }
}
