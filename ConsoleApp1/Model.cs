using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }  // matches table in db
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging1.db");
    }

    // ORM - EF following reasonable conventions, overide easily most typically with annotations
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        [MaxLength(50)]
        public string Topic { get; set; }  // VARCHAR(MAX) - bug that may append to existing string...ad infinitum
                                                // VARCHAR(MAX) cannot be indexed
        // Navigation Property - not stored in Blog, retrieved via BlogId lookup in Posts table
        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }


        // Navigation Property - not stored in Post, retrieved via BlogId lookup in Blogs table
        public Blog Blog { get; set; }
    }
}