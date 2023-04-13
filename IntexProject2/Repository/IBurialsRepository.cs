using IntexProject2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexProject2.Repository
{
    public interface IBurialsRepository
    {
        // ----------------------------------------- GET METHODS -------------------------------------------//
        #region
        public List<Bodyanalysis> GetAllBodyanalysis();
        public List<Burialmain> GetAllBurialmain();
        public List<Textile> GetAllTextiles();
        public Analysis GetAnalysisByTextileID(long textileID);
        public Bodyanalysis GetBodyAnalysisByBodyAnalysisID(int baKeyID);
        public Color GetColorByTextileID(long textileID);


        #endregion
        // ----------------------------------------- CREATE METHODS -------------------------------------------//
        #region

        #endregion
        // ----------------------------------------- UPDATE METHODS -------------------------------------------//
        #region

        #endregion
        // ----------------------------------------- REMOVE METHODS -------------------------------------------//
        #region

        #endregion
    }
}
