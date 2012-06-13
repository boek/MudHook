using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Reflection;
using System.Text;

namespace MudHook.Core
{    
    public class MudHookRepository
    {
        private MudHookContext db = new MudHookContext();

        #region Error Messages
            private const string MissingRole = "Role does not exist";
            private const string MissingUser = "User does not exist";
            private const string TooManyUser = "User already exists";
            private const string TooManyRole = "Role already exists";
            private const string AssignedRole = "Cannot delete a role with assigned users";
        #endregion        

        public int NumberOfUsers
        {
            get
            {
                return this.db.Users.Count();
            }
        }
        public int NumberOfRoles
        {
            get
            {
                return this.db.Roles.Count();
            }
        }

        public MudHookRepository()
        {
            this.db = new MudHookContext();
        }

        public IQueryable<User> GetAllUsers()
        {
            return from user in db.Users
                   orderby user.Username
                   select user;
        }
        public User GetUser(int id)
        {
            return db.Users.SingleOrDefault(user => user.Id == id);
        }
        public User GetUser(string userName)
        {
            return db.Users.SingleOrDefault(user => user.Username == userName);
        }
        public void AddUser(User user)
        {
            db.Users.Add(user);
        }
        public void CreateUser(string userName, string firstName, string lastName, string password, string email, string roleName)
        {
            Role role = GetRole(roleName);

            if (string.IsNullOrEmpty(userName.Trim()))
                throw new ArgumentException("The user name provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(firstName.Trim()) || string.IsNullOrEmpty(lastName.Trim()))
                throw new ArgumentException("The name provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(password.Trim()))
                throw new ArgumentException("The password provided is invalid. Please enter a valid password value.");
            if (string.IsNullOrEmpty(email.Trim()))
                throw new ArgumentException("The e-mail address provided is invalid. Please check the value and try again.");
            if (!RoleExists(role))
                throw new ArgumentException("The role selected for this user does not exist! Contact an administrator!");
            if (this.db.Users.Any(user => user.Username == userName))
                throw new ArgumentException("Username already exists. Please enter a different user name.");

            User newUser = new User()
            {
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                Password = Convert.ToBase64String(MudHookSecurity.GenerateSaltedHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(userName))),
                Email = email,
                Bio = "",
                Status = 1,
                RoleId = role.Id
            };

            try
            {
                AddUser(newUser);
            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception e)
            {
                throw new ArgumentException("The authentication provider returned an error. Please verify your entry and try again. " +
                    "If the problem persists, please contact your system administrator.");
            }

            Save();
        }        

        public IQueryable<Role> GetAllRoles()
        {
            return from roles in db.Roles
                   orderby roles.Id
                   select roles;
        }
        public Role GetRole(int id)
        {
            return db.Roles.FirstOrDefault(role => role.Id == id);
        }
        public Role GetRole(string name)
        {
            return db.Roles.FirstOrDefault(roles => roles.Name == name);
        }
        public Role GetRoleForUser(string userName)
        {
            return GetRoleForUser(GetUser(userName));
        }
        public Role GetRoleForUser(int id)
        {
            return GetRoleForUser(GetUser(id));
        }
        public Role GetRoleForUser(User user)
        {
            if (!UserExists(user))
                throw new ArgumentException(MissingUser);

            return GetRole(user.RoleId);
        }

        public bool UserExists(User user)
        {
            if (user == null)
                return false;

            return (db.Users.SingleOrDefault(u => u.Id == user.Id || u.Username == user.Username) != null);
        }
        public bool RoleExists(Role role)
        {
            if (role == null)
                return false;

            return (db.Roles.SingleOrDefault(r => r.Id == r.Id || r.Name == role.Name) != null);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
