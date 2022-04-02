
using MakoniSoft.DataStore.Models;
//using MakoniSoft.DataStore.Models.Users;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IDataStore
    {
        IEnumerable<Users> GetUsers();

        void SaveUser(Users user);

    }
}
