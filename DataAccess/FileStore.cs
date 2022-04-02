using MakoniSoft.DataStore.Models;
//using MakoniSoft.DataStore.Models.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess
{
    public class FileStore : IDataStore
    {
        private string filePath {get;}
        private FileStore(string path)
        {
            filePath = path;
        }

        public static IDataStore Create(string path)
        {
            return new FileStore(path);
        }

        public IEnumerable<Users> GetUsers()
        {
            using StreamReader r = new StreamReader(filePath);
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<IEnumerable<Users>>(json);
        }

        public void SaveUser(Users user)
        {
            string userData = JsonConvert.SerializeObject(user);
            using StreamWriter fs = new StreamWriter(filePath,true);
            fs.WriteLine(userData);
        }
    }
}
