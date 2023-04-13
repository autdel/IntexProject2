using System;
using System.Linq;
namespace IntexProject2.Models.ViewModels
{
    public class BurialViewModel
    {
        public IQueryable<Burialmain> Burials { get; set; }
        public PageInfo PageInfo { get; set; }

    }
}
