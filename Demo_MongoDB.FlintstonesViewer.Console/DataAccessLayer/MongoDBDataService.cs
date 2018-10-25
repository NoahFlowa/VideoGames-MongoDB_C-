using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Demo_FileIO_NTier.Models;
using Newtonsoft;
using Demo_FileIO_NTier.DataAccessLayer;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Demo_FileIO_NTier.DataAccessLayer

{
    public class MongoDBDataService : IDataService
    {
        static string _connectionString;

        /// <summary>
        /// read the mongoDb collection and load a list of character objects
        /// </summary>
        /// <returns>list of characters</returns>
        public IEnumerable<Videogames> ReadAll()
        {
            List<Videogames> videogames = new List<Videogames>();

            try
            {
                var client = new MongoClient(_connectionString);
                IMongoDatabase database = client.GetDatabase("videogames");
                IMongoCollection<Videogames> videogameList = database.GetCollection<Videogames>("top5");

                videogames = videogameList.Find(Builders<Videogames>.Filter.Empty).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return videogames;
        }

        /// <summary>
        /// write the current list of characters to the mongoDb collection
        /// </summary>
        /// <param name="videogames">list of characters</param>
        public void WriteAll(IEnumerable<Videogames> videogames)
        {
            try
            {
                var client = new MongoClient(_connectionString);
                IMongoDatabase database = client.GetDatabase("videogames");
                IMongoCollection<Videogames> videogameList = database.GetCollection<Videogames>("top5");

                //
                // delete all documents in the collection to reset the collection
                //
                videogameList.DeleteMany(Builders<Videogames>.Filter.Empty);

                videogameList.InsertMany(videogames);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MongoDBDataService()
        {
            _connectionString = DataSettings.connectionString;
        }
    }
}
