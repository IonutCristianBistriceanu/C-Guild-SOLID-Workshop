using System;
using System.Collections.Generic;
using System.IO;

namespace SOLID_Principles
{
    //Journal implementation and persistance problem
    public class Journal
    {
        private readonly IDb _db;
        
        private List<string> entries = new List<string>();
        private static int _count = 0;

        public Journal(IDb db)
        {
            _db = db;
        }

        public void AddEntry(string text)
        {
            entries.Add($"{_count++}: {text}");
        }

        public void ChangeEntry(int index, string text)
        {
            //Error checking
            entries[index] = $"{index}: {text}";
        }

        public override string ToString()
        {
            return String.Join(Environment.NewLine, entries);
        }

        public void Save()
        {
            _db.SaveToFile(this, "a", false);
            //Repository pattern
        }
    }



    public interface IDb
    {
        void SaveToFile(Journal j, string filename, bool overwrite = false);
    }
    
    public class Db : IDb
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }
    
    public class S
    {
        //Single responsibility principle - Journal
    }
}
