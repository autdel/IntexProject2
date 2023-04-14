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
        public Color GetColorByTextileID(long textileID);
        public Decoration GetDecorationByTextileID(long textileID);
        public Dimension GetDimensionByTextileID(long textileID);
        public Photodata GetPhotoDataByTextileID(long textileID);
        public Structure GetStructureByTextileID(long textileID);
        public Textilefunction GetTextileFunctionByTextileID(long textileID);
        public Yarnmanipulation GetYarnManipulationByTextileID(long textileID);




        #endregion

        // ----------------------------------------- BURIAL INFO GET METHODS -------------------------------------------//
        #region
        public Bodyanalysiskey GetBodyanalysiskeyByBurialID(long burialID);
        public Bodyanalysis GetBodyanalysisByBurialID(long burialID);
        public Burialmain GetBurialmainByBurialID(long burialID);
        public Textile GetTextileByBurialID(long burialID);
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
