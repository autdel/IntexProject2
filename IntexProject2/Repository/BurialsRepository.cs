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


        // ----------------------------------------- GET METHODS -------------------------------------------//
        #region
        public List<Bodyanalysis> GetAllBodyanalysis()
        {
            return context.Bodyanalysis.ToList();
        }

        public List<Burialmain> GetAllBurialmain()
        {
            return context.Burialmain.ToList();
        }

        public IQueryable<Burialmain> Burials => context.Burialmain;
        public List<Textile> GetAllTextiles()
        {
            return context.Textile.ToList();
        }

        public Analysis GetAnalysisByTextileID(long textileID)
        {
            Analysis analysis = ((Analysis)(from t in context.Textile join at in context.AnalysisTextile
                                on textileID equals at.MainTextileid join a in context.Analysis
                                on at.MainAnalysisid equals a.Id select new Analysis
                                {
                                    Id = a.Id,
                                    Analysistype = a.Analysistype,
                                    Doneby = a.Doneby,
                                    Analysisid = a.Analysisid,
                                    Date = a.Date
                                }).FirstOrDefault());
            return analysis;
        }

        public Bodyanalysis GetBodyAnalysisByBodyAnalysisID(int baKeyID)
        {
            Bodyanalysis ban = ((Bodyanalysis)(from bak in context.Bodyanalysiskey join ba in context.Bodyanalysis
                                on baKeyID equals ba.BodyAnalysisId select new Bodyanalysis
                                {
                                    BodyAnalysisId = ba.BodyAnalysisId, DateOfExamination = ba.DateOfExamination, 
                                    PreservationIndex = ba.PreservationIndex, HairColor =  ba.HairColor,
                                    Observations = ba.Observations, Robust = ba.Robust, 
                                    SupraorbitalRidges = ba.SupraorbitalRidges, OrbitEdge = ba.OrbitEdge, 
                                    ParietalBossing = ba.ParietalBossing, Gonion = ba.Gonion, NuchalCrest = ba.NuchalCrest, 
                                    ZygomaticCrest = ba.ZygomaticCrest, SphenooccipitalSynchrondrosis = ba.SphenooccipitalSynchrondrosis,
                                    LamboidSuture = ba.LamboidSuture, SquamosSuture = ba.SquamosSuture, 
                                    ToothAttrition = ba.ToothAttrition, ToothEruption = ba.ToothEruption,
                                    ToothEruptionAgeEstimate = ba.ToothEruptionAgeEstimate, VentralArc = ba.VentralArc, 
                                    SubpubicAngle = ba.SubpubicAngle, SciaticNotch = ba.SciaticNotch, PubicBone = ba.PubicBone, 
                                    PreauricularSulcus = ba.PreauricularSulcus, MedialIpRamus = ba.MedialIpRamus, 
                                    DorsalPitting = ba.DorsalPitting, Femur = ba.Femur,
                                    Humerus = ba.Humerus, FemurHeadDiameter = ba.FemurHeadDiameter, 
                                    HumerusHeadDiameter = ba.HumerusHeadDiameter, FemurLength = ba.FemurLength,
                                    HumerusLength = ba.HumerusLength, Tibia = ba.Tibia, EstimateStature = ba.EstimateStature, 
                                    Osteophytosis = ba.Osteophytosis, CariesPeriodontalDisease = ba.CariesPeriodontalDisease, 
                                    Notes = ba.Notes
                                }).FirstOrDefault());
            return ban;
        }

        public List<Color> GetColorsByTextileID(long textileID)
        {
            List<Color> colors = ((List<Color>)(from t in context.Textile join ct in context.ColorTextile
                        on textileID equals ct.MainTextileid join c in context.Color
                        on ct.MainColorid equals c.Id select new Color
                        {
                            Id = c.Id,
                            Value = c.Value,
                            Colorid = c.Colorid
                        }).Distinct().ToList());
            return colors;
        }

        public Decoration GetDecorationByTextileID(long textileID)
        {
            Decoration decoration = ((Decoration)(from t in context.Textile join dt in context.DecorationTextile
                                on textileID equals dt.MainTextileid join d in context.Decoration
                                on dt.MainDecorationid equals d.Id select new Decoration
                                {
                                    Id = d.Id,
                                    Value = d.Value,
                                    Decorationid = d.Decorationid
                                }).FirstOrDefault());
            return decoration;
        }

        public List<Dimension> GetDimensionsByTextileID(long textileID)
        {
            List<Dimension> dimension = ((List<Dimension>)(from t in context.Textile join dt in context.DimensionTextile
                                on textileID equals dt.MainTextileid join d in context.Dimension
                                on dt.MainDimensionid equals d.Id select new Dimension
                                {
                                    Id = d.Id,
                                    Value = d.Value,
                                    Dimensiontype = d.Dimensiontype,
                                    Dimensionid = d.Dimensionid
                                }).Distinct().ToList());
            return dimension;
        }

        public List<Photodata> GetPhotoDataByTextileID(long textileID)
        {
            List<Photodata> pd = ((List<Photodata>)(from t in context.Textile join pdt in context.PhotodataTextile
                                on textileID equals pdt.MainTextileid join p in context.Photodata
                                on pdt.MainPhotodataid equals p.Id select new Photodata
                                {
                                    Id = p.Id,
                                    Description = p.Description,
                                    Filename = p.Filename,
                                    Photodataid = p.Photodataid,
                                    Date = p.Date,
                                    Url = p.Url
                                }).Distinct().ToList());
            return pd;
        }

        public List<Structure> GetStructuresByTextileID(long textileID)
        {
            List<Structure> structures = ((List<Structure>)(from t in context.Textile join st in context.StructureTextile
                                on textileID equals st.MainTextileid join s in context.Structure
                                on st.MainStructureid equals s.Id select new Structure
                                {
                                    Id = s.Id,
                                    Value = s.Value,
                                    Structureid = s.Structureid
                                }).Distinct().ToList());
            return structures;
        }

        public List<Textilefunction> GetTextileFunctionByTextileID(long textileID)
        {
            List<Textilefunction> function = ((List<Textilefunction>)(from t in context.Textile join tft in context.TextilefunctionTextile
                                on textileID equals tft.MainTextileid join tf in context.Textilefunction
                                on tft.MainTextilefunctionid equals tf.Id select new Textilefunction
                                {
                                    Id = tf.Id,
                                    Value = tf.Value,
                                    Textilefunctionid = tf.Textilefunctionid
                                }).Distinct().ToList());
            return function;
        }

        public List<Yarnmanipulation> GetYarnManipulationByTextileID(long textileID)
        {
            List<Yarnmanipulation> yarn = ((List<Yarnmanipulation>)(from t in context.Textile join ymt in context.YarnmanipulationTextile
                                on textileID equals ymt.MainTextileid join ym in context.Yarnmanipulation
                                on ymt.MainYarnmanipulationid equals ym.Id select new Yarnmanipulation
                                {
                                    Id = ym.Id,
                                    Thickness = ym.Thickness,
                                    Angle = ym.Angle,
                                    Manipulation = ym.Manipulation,
                                    Material = ym.Material,
                                    Count = ym.Count,
                                    Component = ym.Component,
                                    Ply = ym.Ply,
                                    Yarnmanipulationid = ym.Yarnmanipulationid,
                                    Direction = ym.Direction
                                }).Distinct().ToList());
            return yarn;
        }


        public long GetLatestBurialID()
        {
            var burial = context.Burialmain.OrderByDescending(x => x.Id).FirstOrDefault();
            long lastID = burial.Id;
            return lastID;
        }


        #endregion
        // ----------------------------------------- CREATE METHODS -------------------------------------------//


        #region
        public void AddtoDB(Burialmain bm)
        {
            long newID = GetLatestBurialID() + 1;
            bm.Id = newID;
            context.Add(bm);
            context.SaveChanges();
        }
        #endregion
        // ----------------------------------------- UPDATE METHODS -------------------------------------------//
        #region

        #endregion
        // ----------------------------------------- REMOVE METHODS -------------------------------------------//
        #region

        #endregion
    }
}
