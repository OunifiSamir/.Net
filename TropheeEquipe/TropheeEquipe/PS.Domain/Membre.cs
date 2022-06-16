using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PS.Domain
{
   public  class Membre
    {
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }
        [Key]
        public int Identifiant { get; set; }
        [Required(ErrorMessage ="Nom obligatoire")]
        public String Nom { get; set; }
        [Required(ErrorMessage ="Prenom obligatoire")]
        public String Prenom { get; set; }

        public virtual IList<Contrat> contrats { get; set; }
    }
}
