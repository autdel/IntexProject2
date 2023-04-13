using IntexProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexProject2.Repository
{
    public interface IBurialsRepository
    {
        public List<Burialmain> GetAllBurialmain();
        public List<Bodyanalysis> GetAllBodyanalysis();
    }
}
