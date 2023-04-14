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
        public IQueryable<Burialmain> Burials { get; }
        public List<Textile> GetAllTextiles();
        public Analysis GetAnalysisByTextileID(long textileID);
        public Bodyanalysis GetBodyAnalysisByBodyAnalysisID(int baKeyID);
        public List<Color> GetColorsByTextileID(long textileID);
        public Decoration GetDecorationByTextileID(long textileID);
        public List<Dimension> GetDimensionsByTextileID(long textileID);
        public List<Photodata> GetPhotoDataByTextileID(long textileID);
        public List<Structure> GetStructuresByTextileID(long textileID);
        public List<Textilefunction> GetTextileFunctionByTextileID(long textileID);
        public List<Yarnmanipulation> GetYarnManipulationByTextileID(long textileID);
        public long GetLatestBurialID();




        #endregion
        // ----------------------------------------- CREATE METHODS -------------------------------------------//
        #region

        public void AddtoDB(Burialmain bm);


        #endregion
        // ----------------------------------------- UPDATE METHODS -------------------------------------------//
        #region

        #endregion
        // ----------------------------------------- REMOVE METHODS -------------------------------------------//
        #region

        #endregion
    }
}
