using System.Collections.Generic;
using Demo_FileIO_NTier.Models;

namespace Demo_FileIO_NTier.DataAccessLayer
{
    public interface IDataService
    {
        IEnumerable<Videogames> ReadAll();
        void WriteAll(IEnumerable<Videogames> videogames);
    }
}
