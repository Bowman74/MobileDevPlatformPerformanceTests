using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PerfTest2Xamarin.Utilities
{
    public class FileUtilities : IDisposable
    {
        private string filePath;
        private StreamWriter streamWriter = null;

        public FileUtilities(string filePath)
        {
            this.filePath = Path.Combine(filePath, "testFile.txt");
        }

        public void OpenFile() 
        {
            streamWriter = new StreamWriter(filePath);
        }

        public void CloseFile()
        {
            if (streamWriter != null)
            {
                streamWriter.Close();
                streamWriter.Dispose();
                streamWriter = null;
            }
        }

        public void DeleteFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public void CreateFile() 
        {
            if (!File.Exists(filePath))
            {
                using (var stream = File.Create(filePath))
                {
                }
            }
        }

        public void WriteLineToFile(String line) 
        {
            if (!File.Exists(filePath)) 
            {
                this.CreateFile();
            }
            if (streamWriter == null) 
            {
                this.OpenFile();
            }

            streamWriter.WriteLine(line);
        }

        public IList<string> ReadFileContents()
        {
            if (!File.Exists(filePath))
            {
                this.CreateFile();
            }

            var returnValue = new List<String>();

            using (var streamReader = new StreamReader(filePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    returnValue.Add(line);
                }
            }
            return returnValue;
        }

        public void Dispose()
        {
            this.CloseFile();
        }
    }
}
