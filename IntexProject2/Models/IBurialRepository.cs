using System;
using System.Linq;
namespace IntexProject2.Models
{
    public interface IBurialRepository
    {
        IQueryable<Burialmain> Burials { get; }
    }
}
