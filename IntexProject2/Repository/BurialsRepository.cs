using IntexProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexProject2.Repository
{
    public class BurialsRepository : IBurialsRepository
    {
        private BurialDataContext context { get; set; }

        public BurialsRepository(BurialDataContext temp)
        {
            context = temp;
        }

        public List<Burialmain> GetAllBurialmain()
        {
            return context.Burialmain.ToList();
        }

        public List<Bodyanalysis> GetAllBodyanalysis()
        {
            return context.Bodyanalysis.ToList();
        }
    }
}
