using System;
using System.Linq;
namespace IntexProject2.Models
{
    public class EFBurialRepository: IBurialRepository
    {
        private BurialDataContext context { get; set; }

        public EFBurialRepository(BurialDataContext temp)
        {
            context = temp;
        }

        public IQueryable<Burialmain> Burials => context.Burialmain;
    }
}
