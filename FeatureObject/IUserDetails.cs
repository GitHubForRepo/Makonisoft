using MakoniSoft.DataStore.Models;
//using MakoniSoft.DataStore.Models.Users;
using System;
using System.Collections.Generic;

namespace FeatureObject
{
    public interface IUserDetails
    {
        IEnumerable<Users> GetUsers();

        void SaveUser(Users user);
    }
}
