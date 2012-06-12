// -----------------------------------------------------------------------
// <copyright file="MudHook.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace MudHook.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
    }

    public class Meta
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Page
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public string Redirect { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Html { get; set; }
        public string Css { get; set; }
        public string Js { get; set; }
        public string CustomFields { get; set; }
        public DateTime Created { get; set; }
        public bool IsModified { get; set; }
        public DateTime LastModified { get; set; }
        public int Author { get; set; }
        public int Status { get; set; }
        public int Comments { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public int Status { get; set; }
        public int RoleId { get; set; }
    }
}
