using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PerfTest2Xamarin.Utilities
{
    [Table("TestTable")] 
    public class TestTable
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string misc { get; set; }
    }
}
