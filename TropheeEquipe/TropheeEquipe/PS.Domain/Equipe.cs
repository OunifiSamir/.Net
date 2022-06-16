using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
  public   class Equipe
    {
        public String AdresseLocal { get; set; }
        public int EquipeId { get; set; }
        public String Logo { get; set; }
        public String NomEquipe { get; set; }

        public virtual IList<Trophee> trophees { get; set; }
      //  public object Trophees { get; set; }
        public virtual IList<Contrat> contrats { get; set; }
    }
}
