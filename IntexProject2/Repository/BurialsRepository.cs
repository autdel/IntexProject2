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

        public Color GetColorByTextileID(long textileID)
        {
            Color color = ((Color)(from t in context.Textile join ct in context.ColorTextile
                        on textileID equals ct.MainTextileid join c in context.Color
                        on ct.MainColorid equals c.Id select new Color
                        {
                            Id = c.Id,
                            Value = c.Value,
                            Colorid = c.Colorid
                        }).FirstOrDefault());
            return color;
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

        public Dimension GetDimensionByTextileID(long textileID)
        {
            Dimension dimension = ((Dimension)(from t in context.Textile join dt in context.DimensionTextile
                                on textileID equals dt.MainTextileid join d in context.Dimension
                                on dt.MainDimensionid equals d.Id select new Dimension
                                {
                                    Id = d.Id,
                                    Value = d.Value,
                                    Dimensiontype = d.Dimensiontype,
                                    Dimensionid = d.Dimensionid
                                }).FirstOrDefault());
            return dimension;
        }

        public Photodata GetPhotoDataByTextileID(long textileID)
        {
            Photodata pd = ((Photodata)(from t in context.Textile join pdt in context.PhotodataTextile
                                on textileID equals pdt.MainTextileid join p in context.Photodata
                                on pdt.MainPhotodataid equals p.Id select new Photodata
                                {
                                    Id = p.Id,
                                    Description = p.Description,
                                    Filename = p.Filename,
                                    Photodataid = p.Photodataid,
                                    Date = p.Date,
                                    Url = p.Url
                                }).FirstOrDefault());
            return pd;
        }

        public Structure GetStructureByTextileID(long textileID)
        {
            Structure structures = ((Structure)(from t in context.Textile join st in context.StructureTextile
                                on textileID equals st.MainTextileid join s in context.Structure
                                on st.MainStructureid equals s.Id select new Structure
                                {
                                    Id = s.Id,
                                    Value = s.Value,
                                    Structureid = s.Structureid
                                }).FirstOrDefault());
            return structures;
        }

        public Textilefunction GetTextileFunctionByTextileID(long textileID)
        {
            Textilefunction function = ((Textilefunction)(from t in context.Textile join tft in context.TextilefunctionTextile
                                on textileID equals tft.MainTextileid join tf in context.Textilefunction
                                on tft.MainTextilefunctionid equals tf.Id select new Textilefunction
                                {
                                    Id = tf.Id,
                                    Value = tf.Value,
                                    Textilefunctionid = tf.Textilefunctionid
                                }).FirstOrDefault());
            return function;
        }

        public Yarnmanipulation GetYarnManipulationByTextileID(long textileID)
        {
            Yarnmanipulation yarn = ((Yarnmanipulation)(from t in context.Textile join ymt in context.YarnmanipulationTextile
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
                                }).FirstOrDefault());
            return yarn;
        }


        public long GetLatestBurialID()
        {
            var burial = context.Burialmain.OrderByDescending(x => x.Id).FirstOrDefault();
            long lastID = burial.Id;
            return lastID;
        }


        #endregion

        // ----------------------------------------- BURIAL INFO GET METHODS -------------------------------------------//
        #region
        public Bodyanalysiskey GetBodyanalysiskeyByBurialID(long burialID)
        {
            Bodyanalysiskey bank = ((Bodyanalysiskey)(from b in context.Burialmain join bmba in context.BurialmainBodyanalysis on
                                               burialID equals bmba.Id join bak in context.Bodyanalysiskey on 
                                               bmba.BodyAnalysisKeyId equals bak.BodyAnalysisKeyId select new Bodyanalysiskey
                                {
                                    BodyAnalysisKeyId = bak.BodyAnalysisKeyId,
                                    SquareNorthSouth = bak.SquareNorthSouth,
                                    NorthSouth = bak.NorthSouth,
                                    SquareEastWest = bak.SquareEastWest,
                                    EastWest = bak.EastWest,
                                    Area = bak.Area,
                                    BurialNumber = bak.BurialNumber
                                }).FirstOrDefault());
            return bank;
        }
        public Bodyanalysis GetBodyanalysisByBurialID(long burialID)
        {
            Bodyanalysis ban = ((Bodyanalysis)(from b in context.Burialmain join bmba in context.BurialmainBodyanalysis on
                                               burialID equals bmba.Id join bak in context.Bodyanalysiskey on 
                                               bmba.BodyAnalysisKeyId equals bak.BodyAnalysisKeyId join ba in context.Bodyanalysis
                                on bak.BodyAnalysisKeyId equals ba.BodyAnalysisId select new Bodyanalysis
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

        public Burialmain GetBurialmainByBurialID(long burialID)
        {
            return context.Burialmain.Where(x => x.Id == burialID).FirstOrDefault();
        }

        public Textile GetTextileByBurialID(long burialID)
        {
            Textile textile = ((Textile)(from b in context.Burialmain join bmt in context.BurialmainTextile
                                        on burialID equals bmt.MainBurialmainid join t in context.Textile on
                                        bmt.MainTextileid equals t.Id select new Textile
                                        {
                                            Id = t.Id,
                                            Locale = t.Locale,
                                            Textileid = t.Textileid,
                                            Description = t.Description,
                                            Burialnumber = t.Burialnumber,
                                            Estimatedperiod = t.Estimatedperiod,
                                            Sampledate = t.Sampledate,
                                            Photographeddate = t.Photographeddate,
                                            Direction = t.Direction
                                        }).FirstOrDefault());
            return textile;
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
        public Burialmain Edit(long id)
        {
            return context.Burialmain.Where(x => x.Id == id).FirstOrDefault();
        }
        public void SaveToDB(Burialmain bm)
        {
            Burialmain bmain = context.Burialmain.Where(x => x.Id == bm.Id).FirstOrDefault();

            bmain = bm;

            context.Burialmain.Update(bm);
            context.SaveChanges();
        }
        #endregion
        // ----------------------------------------- REMOVE METHODS -------------------------------------------//
        #region
        public void RemoveEntry(long id)
        {
            Burialmain bm = context.Burialmain.Where(x => x.Id == id).FirstOrDefault();
            context.Remove(bm);
            context.SaveChanges();
        }
        #endregion
    }
}
