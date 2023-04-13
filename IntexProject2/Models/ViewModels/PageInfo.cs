using System;
namespace IntexProject2.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BurialsPerPage { get; set; }
        public int CurrentPage { get; set; }

        // Calculate num pages needed
        public int TotalPages => (int)Math.Ceiling((double)TotalNumBooks / BurialsPerPage);
    }
}


