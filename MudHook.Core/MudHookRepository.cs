using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Reflection;
using System.Text;
using System.Data;
using System.Data.Entity;

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
        public void EditUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            Save();
        }
        public void CreateUser(string userName, string realName, string password, string email, string roleName)
        {
            Role role = GetRole(roleName);

            if (string.IsNullOrEmpty(userName.Trim()))
                throw new ArgumentException("The user name provided is invalid. Please check the value and try again.");
            if (string.IsNullOrEmpty(realName.Trim()))
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
                RealName = realName,
                Password = Convert.ToBase64String(MudHookSecurity.GenerateSaltedHash(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(userName))),
                Email = email,
                Bio = "",
                Status = UserStatus.active,
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

        public IQueryable<Post> GetAllPosts()
        {
            return from post in db.Posts
                   orderby post.Created ascending
                   select post;
        }
        public Post GetPost(int id)
        {
            //return db.Posts.Include(t => t).SingleOrDefault(post => post.Id == id);
            //return db.Posts.Where(p => p.Id == id).Include(p => p.AvailableTags).FirstOrDefault();
            //Post post = db.Posts.Include(t => t.AvailableTags).Where(p => p.Id == id).FirstOrDefault();
            Post post = db.Posts.Where(p => p.Id == id).FirstOrDefault();
            var tags = db.Tags.ToList<Tag>();
            post.AvailableTags = tags;
            return post;
        }
        public Post GetPost(string slug)
        {
            return db.Posts.SingleOrDefault(post => post.Slug == slug);
        }
        public void AddPost(Post post)
        {
            db.Posts.Add(post);
        }
        public void EditPost(Post post)
        {
            db.Entry(post).State = EntityState.Modified;
            Save();
        }
        public void DeletePost(int id)
        {
            Post post = GetPost(id);
            db.Posts.Remove(post);
            Save();
        }
        public void CreatePost()
        {
            throw new NotImplementedException();
        }
        public IQueryable<Post> SearchPosts(string term)
        {
            return from post in db.Posts
                   where post.Html.Contains(term)
                   select post;
        }
        public IList<Comment> GetCommentsByPost(int id)
        {
            return (from comment in db.Comments
                    where comment.PostId == id                        
                    select comment).ToList<Comment>();
        }

        public IQueryable<Page> GetAllPages()
        {
            return from page in db.Pages
                   select page;
        }
        public Page GetPage(int id)
        {
            return db.Pages.FirstOrDefault(page => page.Id == id);
        }
        public Page GetPage(string slug)
        {
            return db.Pages.FirstOrDefault(page => page.Slug == slug);
        }          
        public void AddPage(Page page)
        {
            db.Pages.Add(page);
            Save();
        }
        public void EditPage(Page page)
        {
            db.Entry(page).State = EntityState.Modified;
            Save();
        }
        public void DeletePage(int id)
        {
            Page page = GetPage(id);
            db.Pages.Remove(page);
            Save();
        }

        public IQueryable<Tag> GetAllTags()
        {
            return from tag in db.Tags
                   select tag;
        }
        public Tag GetTag(int id)
        {
            return db.Tags.FirstOrDefault(tag => tag.Id == id);
        }
        public Tag GetTag(string name)
        {
            return db.Tags.FirstOrDefault(tag => tag.Name == name);
        }
        public void AddTag(Tag tag)
        {
            db.Tags.Add(tag);
            Save();
        }
        public void EditTag(Tag tag)
        {
            db.Entry(tag).State = EntityState.Modified;
            Save();
        }
        public void DeleteTag(int id)
        {
            Tag tag = GetTag(id);
            db.Tags.Remove(tag);
            Save();
        }

        public Meta GetMeta(string key)
        {
            return db.Meta.FirstOrDefault(m => m.Key == key);
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
