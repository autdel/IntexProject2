﻿using System;
using System.Linq;
namespace IntexProject2.Models.ViewModels
{
    public class BurialViewModel
    {
        public IQueryable<Burialmain> Burials { get; set; }
        public PageInfo PageInfo { get; set; }
        public string SquareNSFilter { get; set; }
        public string NSFilter { get; set; }
        public string SquareEWFilter { get; set; }
        public string EWFilter { get; set; }
        public string BurialNumFilter { get; set; }
        public string AreaFilter { get; set; }
        public string AgeFilter { get; set; }
        public string HairColorFilter { get; set; }
        public string BurialDepthFilter { get; set; }
        public string HeadDirectionFilter { get; set; }
        public string SexFilter { get; set; }

    }
}
