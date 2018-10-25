using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_FileIO_NTier.DataAccessLayer;
using Demo_FileIO_NTier.Models;

namespace Demo_FileIO_NTier.BusinessLogicLayer
{
    class VGBLL
    {
        IDataService _dataService;
        List<Videogames> _videogames;

        public VGBLL(IDataService dataservice)
        {
            _dataService = dataservice;
        }

        /// <summary>
        /// get IEnumberable of all characters sorted by Id
        /// </summary>
        /// <param name="success">operation status</param>
        /// <param name="message">error message</param>
        /// <returns></returns>
        public IEnumerable<Videogames> GetVideoGames(out bool success, out string message)
        {
            _videogames = null;
            success = false;
            message = "";
            try
            {
                _videogames = _dataService.ReadAll() as List<Videogames>;
                _videogames.OrderBy(c => c.Id);

                if (_videogames.Count > 0)
                {
                    success = true;
                }
                else
                {
                    message = "It appears there is no data in the file.";
                }
            }
            catch (FileNotFoundException)
            {
                message = "Unable to locate the data file.";
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return _videogames;
        }
    }
}
