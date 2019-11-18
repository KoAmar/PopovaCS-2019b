using BlazorApp.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Data.Users
{
    public class CurrentUser
    {
        private User _currentUser;

        public CurrentUser()
        {
            _currentUser = null;
        }

        public void SetCurrentUser(User user) => _currentUser = user;

        public string GetLogin()
        {
            if(_currentUser == null){return "";}
            else return _currentUser.Login;
        }

        public string GetEmail()
        {
            if(_currentUser == null){return "";}
            else return _currentUser.Login;
        }

        public User.Roles GetRole()
        {
            if(_currentUser == null){return User.Roles.UnAuthorized;}
            else return _currentUser.Role;
        }
        
        public int GetId()
        {
            if(_currentUser == null){return 0;}
            else return _currentUser.Id;
        }
    }
}
