using DataAccess;
using MakoniSoft.DataStore.Models;
//using MakoniSoft.DataStore.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeatureObject
{
    public class UserDetails : IUserDetails
    {
        private IDataStore _dataStore { get; set; }
        public UserDetails(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        public IEnumerable<Users> GetUsers()
        {
           return _dataStore.GetUsers();
        }

        public void SaveUser(Users user)
        {
            user.Id = Guid.NewGuid();
            _dataStore.SaveUser(user);
        }
    }
}
