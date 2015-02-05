using Android.Content;
using Android.Database.Sqlite;
using System;
using System.Collections.Generic;
using Android.Runtime;

namespace PerfTest2Xamarin.Utilities
{
    [Preserve(AllMembers = true)]
    public class SqLiteUtilitiesAlt : SQLiteOpenHelper 
    {
        private const int DATABASE_VERSION = 1;
        private const string DATABASE_NAME = "testDB";
        private const string TABLE_NAME = "testTable";

        private SQLiteDatabase dbConn = null;

        public SqLiteUtilitiesAlt(Context context) : base(context, DATABASE_NAME, null, DATABASE_VERSION)
        {
        }

        public override void OnCreate(SQLiteDatabase db) {
            var createTableQuery = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT, firstName varchar(30), lastName varchar(30), misc TEXT )";

            db.ExecSQL(createTableQuery);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
            db.ExecSQL("DROP TABLE IF EXISTS " + TABLE_NAME);

            this.OnCreate(db);
        }

        public void OpenConnection() {
            if (dbConn!= null) {
                CloseConnection();
            }
            dbConn = this.WritableDatabase;
        }

        public void CloseConnection() 
        {
            if (dbConn == null) 
            {
                throw new Exception("Connection not open to close");
            } 
            else 
            {
                dbConn.Close();
                dbConn = null;
            }
        }

        public void CreateTable() 
        {
            if (dbConn == null) 
            {
                OpenConnection();
            }

            OnUpgrade(dbConn, 0, 0);
        }

        public  void AddRecord(string firstName, string lastName, int index, string misc) 
        {
            if (dbConn == null) 
            {
                OpenConnection();
            }

            ContentValues values = new ContentValues();
            values.Put("firstName", firstName);
            values.Put("lastName", lastName + index);
            values.Put("misc", misc);
            dbConn.InsertOrThrow(TABLE_NAME, null, values);
        }

        public IList<string> GetAllRecords() 
        {
            if (dbConn == null) {
                OpenConnection();
            }

            var returnValue = new List<String>();
            var sqlStatement = "SELECT * FROM " + TABLE_NAME;
            var results = dbConn.RawQuery(sqlStatement, null);

            if (results.MoveToFirst()) {
                do 
                {
                    returnValue.Add(results.GetString(1) + " " + results.GetString(2));
                } while (results.MoveToNext());
            }
            return returnValue;
        }

        public IList<string> GetRecordsWith1() 
        {
            if (dbConn == null) 
            {
                OpenConnection();
            }

            var returnValue = new List<string>();
            var sqlStatement = "SELECT * FROM " + TABLE_NAME + " WHERE lastName LIKE '%1%'";
            var results = dbConn.RawQuery(sqlStatement, null);

            if (results.MoveToFirst())
            {
                do 
                {
                    returnValue.Add(results.GetString(1) + " " + results.GetString(2));
                } while (results.MoveToNext());
            }

            return returnValue;
        }
    }
}