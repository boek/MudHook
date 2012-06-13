using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace MudHook.Core
{     
    public class MudHookReset : DropCreateDatabaseAlways<MudHookContext>
    {
        protected override void Seed(MudHookContext context)
        {
            //Create Roles
            context.Roles.Add(new Role { Id = 1, Name = "Admin" });
            context.Roles.Add(new Role { Id = 2, Name = "User" });

            //Create User
            context.Users.Add(new User { Id = 1, RoleId = 1, Username = "jeffboek", Password = Convert.ToBase64String(MudHookSecurity.GenerateSaltedHash(Encoding.UTF8.GetBytes("1234qwer"), Encoding.UTF8.GetBytes("jeffboek"))), FirstName = "Jeff", LastName = "Boek", Bio = "", Email = "j@jboek.com", Status = 1 });

            //Create Tags
            context.Tags.Add(new Tag { Id = 1, Name = "TEST TAG 1 " });
            context.Tags.Add(new Tag { Id = 2, Name = "TEST TAG 2 " });

            //Create Posts
            context.Posts.Add(new Post { Id = 1, TagId = 1, Title = "Test1", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2011, 12, 25), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 2, TagId = 2, Title = "Test2", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 3, 10), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 3, TagId = 2, Title = "Test3", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 4, 15), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 4, TagId = 2, Title = "Test4", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 4, 20), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 5, TagId = 2, Title = "Test5", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 4, 25), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 6, TagId = 2, Title = "Test6", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 4, 30), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 7, TagId = 2, Title = "Test7", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 4, 1), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 8, TagId = 1, Title = "Test8", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 4, 1), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 9, TagId = 1, Title = "Test9", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 5, 1), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 10, TagId = 1, Title = "Test10", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 5, 4), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 11, TagId = 2, Title = "Test11", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 5, 5), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 12, TagId = 2, Title = "Test12", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 5, 6), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 13, TagId = 2, Title = "Test13", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 5, 7), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 14, TagId = 1, Title = "Test14", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 6, 1), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
            context.Posts.Add(new Post { Id = 15, TagId = 1, Title = "Test15", Slug = "Test1", Description = "Description for Post 1", Html = "<p>Post numba 1!", Css = "", Js = "", CustomFields = "", Created = new DateTime(2012, 6, 6), IsModified = false, LastModified = new DateTime(2012, 5, 1), Author = 1, Status = 1, Comments = 0 });
        }
    }
}
