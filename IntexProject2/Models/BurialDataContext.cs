﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IntexProject2.Models
{
    public partial class BurialDataContext : DbContext
    {
        public BurialDataContext()
        {
        }

        public BurialDataContext(DbContextOptions<BurialDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Analysis> Analysis { get; set; }
        public virtual DbSet<AnalysisTextile> AnalysisTextile { get; set; }
        public virtual DbSet<Bodyanalysis> Bodyanalysis { get; set; }
        public virtual DbSet<Bodyanalysiskey> Bodyanalysiskey { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Burialmain> Burialmain { get; set; }
        public virtual DbSet<BurialmainBodyanalysis> BurialmainBodyanalysis { get; set; }
        public virtual DbSet<BurialmainTextile> BurialmainTextile { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<ColorTextile> ColorTextile { get; set; }
        public virtual DbSet<Decoration> Decoration { get; set; }
        public virtual DbSet<DecorationTextile> DecorationTextile { get; set; }
        public virtual DbSet<Dimension> Dimension { get; set; }
        public virtual DbSet<DimensionTextile> DimensionTextile { get; set; }
        public virtual DbSet<Newsarticle> Newsarticle { get; set; }
        public virtual DbSet<Photodata> Photodata { get; set; }
        public virtual DbSet<PhotodataTextile> PhotodataTextile { get; set; }
        public virtual DbSet<Photoform> Photoform { get; set; }
        public virtual DbSet<Structure> Structure { get; set; }
        public virtual DbSet<StructureTextile> StructureTextile { get; set; }
        public virtual DbSet<Teammember> Teammember { get; set; }
        public virtual DbSet<Textile> Textile { get; set; }
        public virtual DbSet<Textilefunction> Textilefunction { get; set; }
        public virtual DbSet<TextilefunctionTextile> TextilefunctionTextile { get; set; }
        public virtual DbSet<Yarnmanipulation> Yarnmanipulation { get; set; }
        public virtual DbSet<YarnmanipulationTextile> YarnmanipulationTextile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=aws_rds_db;Database=BurialData; Username=postgres; password=RootUser403");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Analysis>(entity =>
            {
                entity.ToTable("analysis");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Analysisid).HasColumnName("analysisid");

                entity.Property(e => e.Analysistype).HasColumnName("analysistype");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Doneby)
                    .HasColumnName("doneby")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AnalysisTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainAnalysisid, e.MainTextileid })
                    .HasName("main$analysis_textile_pkey");

                entity.ToTable("analysis_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainAnalysisid })
                    .HasName("idx_main$analysis_textile_main$textile_main$analysis");

                entity.Property(e => e.MainAnalysisid).HasColumnName("main$analysisid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Bodyanalysis>(entity =>
            {
                entity.ToTable("bodyanalysis");

                entity.Property(e => e.BodyAnalysisId).HasDefaultValueSql("1");

                entity.Property(e => e.CariesPeriodontalDisease)
                    .HasColumnName("Caries_Periodontal_Disease")
                    .HasColumnType("character varying");

                entity.Property(e => e.DateOfExamination).HasMaxLength(40);

                entity.Property(e => e.DorsalPitting).HasColumnType("character varying");

                entity.Property(e => e.EstimateStature).HasColumnType("numeric");

                entity.Property(e => e.Femur).HasColumnType("character varying");

                entity.Property(e => e.FemurHeadDiameter).HasColumnType("numeric");

                entity.Property(e => e.FemurLength).HasColumnType("numeric");

                entity.Property(e => e.Gonion).HasColumnType("character varying");

                entity.Property(e => e.HairColor).HasColumnType("character varying");

                entity.Property(e => e.Humerus).HasColumnType("character varying");

                entity.Property(e => e.HumerusHeadDiameter).HasColumnType("numeric");

                entity.Property(e => e.HumerusLength).HasColumnType("numeric");

                entity.Property(e => e.LamboidSuture).HasColumnType("character varying");

                entity.Property(e => e.MedialIpRamus)
                    .HasColumnName("Medial_IP_Ramus")
                    .HasColumnType("character varying");

                entity.Property(e => e.Notes).HasColumnType("character varying");

                entity.Property(e => e.NuchalCrest).HasColumnType("character varying");

                entity.Property(e => e.Observations).HasColumnType("character varying");

                entity.Property(e => e.OrbitEdge).HasColumnType("character varying");

                entity.Property(e => e.Osteophytosis).HasColumnType("character varying");

                entity.Property(e => e.ParietalBossing).HasColumnType("character varying");

                entity.Property(e => e.PreauricularSulcus).HasColumnType("character varying");

                entity.Property(e => e.PreservationIndex).HasColumnType("numeric");

                entity.Property(e => e.PubicBone).HasColumnType("character varying");

                entity.Property(e => e.Robust).HasColumnType("character varying");

                entity.Property(e => e.SciaticNotch).HasColumnType("character varying");

                entity.Property(e => e.SphenooccipitalSynchrondrosis).HasColumnType("character varying");

                entity.Property(e => e.SquamosSuture).HasColumnType("character varying");

                entity.Property(e => e.SubpubicAngle).HasColumnType("character varying");

                entity.Property(e => e.SupraorbitalRidges).HasColumnType("character varying");

                entity.Property(e => e.Tibia).HasColumnType("numeric");

                entity.Property(e => e.ToothAttrition).HasColumnType("character varying");

                entity.Property(e => e.ToothEruption).HasColumnType("character varying");

                entity.Property(e => e.ToothEruptionAgeEstimate).HasColumnType("character varying");

                entity.Property(e => e.VentralArc).HasColumnType("character varying");

                entity.Property(e => e.ZygomaticCrest).HasColumnType("character varying");
            });

            modelBuilder.Entity<Bodyanalysiskey>(entity =>
            {
                entity.ToTable("bodyanalysiskey");

                entity.HasIndex(e => new { e.SquareNorthSouth, e.NorthSouth, e.SquareEastWest, e.EastWest, e.Area, e.BurialNumber })
                    .HasName("bodyanalysiskey_constraint")
                    .IsUnique();

                entity.Property(e => e.BodyAnalysisKeyId).ValueGeneratedNever();

                entity.Property(e => e.Area).HasMaxLength(200);

                entity.Property(e => e.BurialNumber).HasMaxLength(200);

                entity.Property(e => e.EastWest).HasMaxLength(200);

                entity.Property(e => e.NorthSouth).HasMaxLength(200);

                entity.Property(e => e.SquareEastWest).HasMaxLength(200);

                entity.Property(e => e.SquareNorthSouth).HasMaxLength(200);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasMaxLength(300);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Burialmain>(entity =>
            {
                entity.ToTable("burialmain");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adultsubadult)
                    .HasColumnName("adultsubadult")
                    .HasMaxLength(200);

                entity.Property(e => e.Ageatdeath)
                    .HasColumnName("ageatdeath")
                    .HasMaxLength(200);

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(200);

                entity.Property(e => e.Burialid).HasColumnName("burialid");

                entity.Property(e => e.Burialmaterials)
                    .HasColumnName("burialmaterials")
                    .HasMaxLength(5);

                entity.Property(e => e.Burialnumber)
                    .HasColumnName("burialnumber")
                    .HasMaxLength(200);

                entity.Property(e => e.Clusternumber)
                    .HasColumnName("clusternumber")
                    .HasMaxLength(200);

                entity.Property(e => e.Dataexpertinitials)
                    .HasColumnName("dataexpertinitials")
                    .HasMaxLength(200);

                entity.Property(e => e.Dateofexcavation).HasColumnName("dateofexcavation");

                entity.Property(e => e.Depth)
                    .HasColumnName("depth")
                    .HasMaxLength(200);

                entity.Property(e => e.Eastwest)
                    .HasColumnName("eastwest")
                    .HasMaxLength(200);

                entity.Property(e => e.Excavationrecorder)
                    .HasColumnName("excavationrecorder")
                    .HasMaxLength(100);

                entity.Property(e => e.Facebundles)
                    .HasColumnName("facebundles")
                    .HasMaxLength(200);

                entity.Property(e => e.Fieldbookexcavationyear)
                    .HasColumnName("fieldbookexcavationyear")
                    .HasMaxLength(200);

                entity.Property(e => e.Fieldbookpage)
                    .HasColumnName("fieldbookpage")
                    .HasMaxLength(200);

                entity.Property(e => e.Goods)
                    .HasColumnName("goods")
                    .HasMaxLength(200);

                entity.Property(e => e.Hair)
                    .HasColumnName("hair")
                    .HasMaxLength(5);

                entity.Property(e => e.Haircolor)
                    .HasColumnName("haircolor")
                    .HasMaxLength(200);

                entity.Property(e => e.Headdirection)
                    .HasColumnName("headdirection")
                    .HasMaxLength(200);

                entity.Property(e => e.Length)
                    .HasColumnName("length")
                    .HasMaxLength(200);

                entity.Property(e => e.Northsouth)
                    .HasColumnName("northsouth")
                    .HasMaxLength(200);

                entity.Property(e => e.Photos)
                    .HasColumnName("photos")
                    .HasMaxLength(5);

                entity.Property(e => e.Preservation)
                    .HasColumnName("preservation")
                    .HasMaxLength(200);

                entity.Property(e => e.Samplescollected)
                    .HasColumnName("samplescollected")
                    .HasMaxLength(200);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(200);

                entity.Property(e => e.Shaftnumber)
                    .HasColumnName("shaftnumber")
                    .HasMaxLength(200);

                entity.Property(e => e.Southtofeet)
                    .HasColumnName("southtofeet")
                    .HasMaxLength(200);

                entity.Property(e => e.Southtohead)
                    .HasColumnName("southtohead")
                    .HasMaxLength(200);

                entity.Property(e => e.Squareeastwest)
                    .HasColumnName("squareeastwest")
                    .HasMaxLength(200);

                entity.Property(e => e.Squarenorthsouth)
                    .HasColumnName("squarenorthsouth")
                    .HasMaxLength(200);

                entity.Property(e => e.Text)
                    .HasColumnName("text")
                    .HasMaxLength(2000);

                entity.Property(e => e.Westtofeet)
                    .HasColumnName("westtofeet")
                    .HasMaxLength(200);

                entity.Property(e => e.Westtohead)
                    .HasColumnName("westtohead")
                    .HasMaxLength(200);

                entity.Property(e => e.Wrapping)
                    .HasColumnName("wrapping")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<BurialmainBodyanalysis>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("burialmain_bodyanalysis");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<BurialmainTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainBurialmainid, e.MainTextileid })
                    .HasName("main$burialmain_textile_pkey");

                entity.ToTable("burialmain_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainBurialmainid })
                    .HasName("idx_main$burialmain_textile_main$textile_main$burialmain");

                entity.Property(e => e.MainBurialmainid).HasColumnName("main$burialmainid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("color");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Colorid).HasColumnName("colorid");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<ColorTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainColorid, e.MainTextileid })
                    .HasName("main$color_textile_pkey");

                entity.ToTable("color_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainColorid })
                    .HasName("idx_main$color_textile_main$textile_main$color");

                entity.Property(e => e.MainColorid).HasColumnName("main$colorid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Decoration>(entity =>
            {
                entity.ToTable("decoration");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Decorationid).HasColumnName("decorationid");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<DecorationTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainDecorationid, e.MainTextileid })
                    .HasName("main$decoration_textile_pkey");

                entity.ToTable("decoration_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainDecorationid })
                    .HasName("idx_main$decoration_textile_main$textile_main$decoration");

                entity.Property(e => e.MainDecorationid).HasColumnName("main$decorationid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Dimension>(entity =>
            {
                entity.ToTable("dimension");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dimensionid).HasColumnName("dimensionid");

                entity.Property(e => e.Dimensiontype)
                    .HasColumnName("dimensiontype")
                    .HasMaxLength(500);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<DimensionTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainDimensionid, e.MainTextileid })
                    .HasName("main$dimension_textile_pkey");

                entity.ToTable("dimension_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainDimensionid })
                    .HasName("idx_main$dimension_textile_main$textile_main$dimension");

                entity.Property(e => e.MainDimensionid).HasColumnName("main$dimensionid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Newsarticle>(entity =>
            {
                entity.ToTable("newsarticle");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Author)
                    .HasColumnName("author")
                    .HasColumnType("character varying");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("character varying");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("character varying");

                entity.Property(e => e.Urltoimage)
                    .HasColumnName("urltoimage")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Photodata>(entity =>
            {
                entity.ToTable("photodata");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasMaxLength(200);

                entity.Property(e => e.Photodataid).HasColumnName("photodataid");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<PhotodataTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainPhotodataid, e.MainTextileid })
                    .HasName("main$photodata_textile_pkey");

                entity.ToTable("photodata_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainPhotodataid })
                    .HasName("idx_main$photodata_textile_main$textile_main$photodata");

                entity.Property(e => e.MainPhotodataid).HasColumnName("main$photodataid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Photoform>(entity =>
            {
                entity.ToTable("photoform");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(100);

                entity.Property(e => e.Burialnumber)
                    .HasColumnName("burialnumber")
                    .HasMaxLength(10);

                entity.Property(e => e.Eastwest)
                    .HasColumnName("eastwest")
                    .HasMaxLength(1);

                entity.Property(e => e.Filename)
                    .HasColumnName("filename")
                    .HasMaxLength(200);

                entity.Property(e => e.Northsouth)
                    .HasColumnName("northsouth")
                    .HasMaxLength(1);

                entity.Property(e => e.Photodate).HasColumnName("photodate");

                entity.Property(e => e.Photographer)
                    .HasColumnName("photographer")
                    .HasMaxLength(100);

                entity.Property(e => e.Squareeastwest)
                    .HasColumnName("squareeastwest")
                    .HasMaxLength(100);

                entity.Property(e => e.Squarenorthsouth)
                    .HasColumnName("squarenorthsouth")
                    .HasMaxLength(5);

                entity.Property(e => e.Tableassociation)
                    .HasColumnName("tableassociation")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Structure>(entity =>
            {
                entity.ToTable("structure");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Structureid).HasColumnName("structureid");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<StructureTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainStructureid, e.MainTextileid })
                    .HasName("main$structure_textile_pkey");

                entity.ToTable("structure_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainStructureid })
                    .HasName("idx_main$structure_textile_main$textile_main$structure");

                entity.Property(e => e.MainStructureid).HasColumnName("main$structureid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Teammember>(entity =>
            {
                entity.ToTable("teammember");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bio)
                    .HasColumnName("bio")
                    .HasColumnType("character varying");

                entity.Property(e => e.Membername)
                    .HasColumnName("membername")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Textile>(entity =>
            {
                entity.ToTable("textile");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Burialnumber)
                    .HasColumnName("burialnumber")
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Direction)
                    .HasColumnName("direction")
                    .HasMaxLength(200);

                entity.Property(e => e.Estimatedperiod)
                    .HasColumnName("estimatedperiod")
                    .HasMaxLength(200);

                entity.Property(e => e.Locale)
                    .HasColumnName("locale")
                    .HasMaxLength(200);

                entity.Property(e => e.Photographeddate).HasColumnName("photographeddate");

                entity.Property(e => e.Sampledate).HasColumnName("sampledate");

                entity.Property(e => e.Textileid).HasColumnName("textileid");
            });

            modelBuilder.Entity<Textilefunction>(entity =>
            {
                entity.ToTable("textilefunction");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Textilefunctionid).HasColumnName("textilefunctionid");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TextilefunctionTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainTextilefunctionid, e.MainTextileid })
                    .HasName("main$textilefunction_textile_pkey");

                entity.ToTable("textilefunction_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainTextilefunctionid })
                    .HasName("idx_main$textilefunction_textile");

                entity.Property(e => e.MainTextilefunctionid).HasColumnName("main$textilefunctionid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.Entity<Yarnmanipulation>(entity =>
            {
                entity.ToTable("yarnmanipulation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Angle)
                    .HasColumnName("angle")
                    .HasMaxLength(20);

                entity.Property(e => e.Component)
                    .HasColumnName("component")
                    .HasMaxLength(200);

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasMaxLength(100);

                entity.Property(e => e.Direction)
                    .HasColumnName("direction")
                    .HasMaxLength(20);

                entity.Property(e => e.Manipulation)
                    .HasColumnName("manipulation")
                    .HasMaxLength(100);

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasMaxLength(100);

                entity.Property(e => e.Ply)
                    .HasColumnName("ply")
                    .HasMaxLength(20);

                entity.Property(e => e.Thickness)
                    .HasColumnName("thickness")
                    .HasMaxLength(20);

                entity.Property(e => e.Yarnmanipulationid).HasColumnName("yarnmanipulationid");
            });

            modelBuilder.Entity<YarnmanipulationTextile>(entity =>
            {
                entity.HasKey(e => new { e.MainYarnmanipulationid, e.MainTextileid })
                    .HasName("main$yarnmanipulation_textile_pkey");

                entity.ToTable("yarnmanipulation_textile");

                entity.HasIndex(e => new { e.MainTextileid, e.MainYarnmanipulationid })
                    .HasName("idx_main$yarnmanipulation_textile");

                entity.Property(e => e.MainYarnmanipulationid).HasColumnName("main$yarnmanipulationid");

                entity.Property(e => e.MainTextileid).HasColumnName("main$textileid");
            });

            modelBuilder.HasSequence("excelimporter$template_nr_mxseq");

            modelBuilder.HasSequence("system$filedocument_fileid_mxseq");

            modelBuilder.HasSequence("system$queuedtask_sequence_mxseq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
