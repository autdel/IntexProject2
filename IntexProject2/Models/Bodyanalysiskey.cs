using System;
using System.Collections.Generic;

namespace IntexProject2.Models
{
    public partial class Bodyanalysiskey
    {
        public int BodyAnalysisKeyId { get; set; }
        public string SquareNorthSouth { get; set; }
        public string NorthSouth { get; set; }
        public string SquareEastWest { get; set; }
        public string EastWest { get; set; }
        public string Area { get; set; }
        public string BurialNumber { get; set; }
    }
}
