using PS.Data.Infrastructure;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Services
{
   public class EquipeService :Service<Equipe> , IEquipeService
    {
        public EquipeService(IUnitOfWork uow) : base(uow)
        {

        }

        public DateTime DatePremierChampionnat(Equipe e)
        {

            return e.trophees
                .OrderBy(t => t.DateTrophee)
                .Where(t => t.TypeTrophee == "Championnat")
                .Select(t => t.DateTrophee).First();
        }

        public List<Entraineur> ListEntraineurParEquipe(Equipe e)
        {
            return e.contrats
               .Select(c => c.membre)
               .OfType<Entraineur>()
               .ToList();
        }

        public List<Joueur> ListJoueurTrophee(Trophee t)
        {
            return t.equipe.contrats
                .Where(c => (t.DateTrophee - c.DateContrat).TotalDays < c.DureeMois * 30)
                .Select(c => c.membre).OfType<Joueur>().ToList();
        }

        public double SommeRecompence(Equipe e)
        {
            return e.trophees.Sum(t => t.Recompense);
        }
    }
}
