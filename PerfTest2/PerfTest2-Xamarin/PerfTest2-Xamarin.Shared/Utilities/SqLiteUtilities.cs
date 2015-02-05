using System;
using System.Collections.Generic;
using SQLite;
using System.IO;
using System.Linq;

namespace PerfTest2Xamarin.Utilities
{
    public class SqLiteUtilities
    {

        private const int DATABASE_VERSION = 1;
        private const string DATABASE_NAME = "testDB.sql3";
        private const string TABLE_NAME = "testTable";

        private string dbPath;
        private SQLiteConnection dbConn = null;

        public SqLiteUtilities(string path)
        {
            dbPath = path;
        }

        public void OpenConnection()
        {
            if (dbConn != null)
            {
                CloseConnection();
            }
            dbConn = new SQLiteConnection(Path.Combine(dbPath, DATABASE_NAME));
        }

        public void CloseConnection()
        {
            if (dbConn == null)
            {
                throw new InvalidOperationException("Connection not open to close");
            }
            else
            {
                dbConn.Close();
                dbConn = null;
            }
        }

        public void DeleteFile()
        {
            if (dbConn != null)
            {
                CloseConnection();
            }
            if (File.Exists(Path.Combine(dbPath, DATABASE_NAME)))
            {
                File.Delete(Path.Combine(dbPath, DATABASE_NAME));
            }
        }

        public void CreateTable()
        {
            if (dbConn == null)
            {
                OpenConnection();
            }
            dbConn.CreateTable<TestTable>();
        }

        public void AddRecord(string fName, string lName, int i, string m)
        {
            if (dbConn == null)
            {
                OpenConnection();
            }

            var testRecord = new TestTable {firstName = fName, id = 0, lastName = lName + i, misc = m};

            dbConn.Insert(testRecord);
        }

        public IList<string> GetAllRecords()
        {
            if (dbConn == null)
            {
                OpenConnection();
            }

            var results = (from t in dbConn.Table<TestTable>() select t ).ToList(); 

            var returnList = new List<string>();

            foreach (var result in results)
            {
                returnList.Add(string.Format("{0} {1}", result.firstName, result.lastName));    
            }
            return returnList;
        }

        public IList<string> GetRecordsWith1()
        {
            if (dbConn == null)
            {
                OpenConnection();
            }

            var results = (from t in dbConn.Table<TestTable>() where t.lastName.Contains("1") select t).ToList(); 

            var returnList = new List<string>();

            foreach (var result in results)
            {
                returnList.Add(string.Format("{0} {1}", result.firstName, result.lastName));
            }
            return returnList;
        }
    }
}