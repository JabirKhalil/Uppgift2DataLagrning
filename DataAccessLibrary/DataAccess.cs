using DataAccessLibrary.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;

namespace DataAccessLibrary
{
  
    public class DataAccess
    {
        private static readonly string _dbname = "DataC.db";
        private static readonly string _dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, _dbname);
        public static async Task InitializeDatabaseAsync()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync(_dbname, CreationCollisionOption.OpenIfExists);
            Console.WriteLine($"dbPath = {_dbpath}");

            using (var db = new SqliteConnection($"Filename={_dbpath}"))
            {
                db.Open();

                var query = "CREATE TABLE IF NOT EXISTS CaseTable (Id INTEGER PRIMARY KEY, Category NVARCHAR(50) NULL, Info NVARCHAR(200) NULL, CaseStatus NVARCHAR(50) NULL)";
                var cmd = new SqliteCommand(query, db);

                cmd.ExecuteReader();
                db.Close();
            }
        }

        public static async Task AddAsync(string input, string input1, string input2)
        {
            using (var db = new SqliteConnection($"Filename={_dbpath}"))
            {
                db.Open();

                var query = "INSERT INTO CaseTable (Id, Category, Info, CaseStatus) VALUES(NULL, @Category, @Info, @CaseStatus)";
                var cmd = new SqliteCommand(query, db);

                cmd.Parameters.AddWithValue("@Category", input);
                cmd.Parameters.AddWithValue("@Info", input1);
                cmd.Parameters.AddWithValue("@CaseStatus", input2);
                await cmd.ExecuteReaderAsync();
                db.Close();
            }

        }

        public static IEnumerable<CaseData> GetAll()
        {
            var caseDatas= new List<CaseData>();

            using (var db = new SqliteConnection($"Filename={_dbpath}"))
            {
                db.Open();

                var query = "SELECT * FROM CaseTable";
                var cmd = new SqliteCommand(query, db);

                var result = cmd.ExecuteReader();


                while (result.Read())
                {
                    var caseData = new CaseData(result.GetInt32(0), result.GetString(1), result.GetString(2), result.GetString(3));
                    caseDatas.Add(caseData);
                }

                db.Close();

                return caseDatas;
            }
        }


    }
}
