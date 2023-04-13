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
