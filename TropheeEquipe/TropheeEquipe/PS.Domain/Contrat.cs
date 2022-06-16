using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
  public  class Contrat
    {
        public DateTime DateContrat { get; set; }
        [Range(0,24)]
        public int DureeMois { get; set; }
        public Double Salire { get; set; }



        public int EquipeId { get; set; }  //pour permeter d'ajouter une cle etranger a contrat aussi pour memebre
        [ForeignKey("EquipeId")]
        public virtual Equipe equipe { get; set; }






        public int MembreId { get; set; }
        [ForeignKey("MembreId")]
        public virtual Membre membre { get; set; }
    }
}
