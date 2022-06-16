using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
 public  class Trophee
    {
        [DataType(DataType.Date)]
        public DateTime DateTrophee { get; set; }
        [DataType(DataType.Currency)]
        public Double Recompense { get; set; }
        public int TropheeId { get; set; }
        public String TypeTrophee { get; set; }
      
        public int EquipeId { get; set; }
        [ForeignKey("EquipeId")]
        public virtual Equipe equipe { get; set; }

    }
}
