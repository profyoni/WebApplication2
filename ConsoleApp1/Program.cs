using System;
using System.Linq;
using EFGetStarted;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var blogsdb = new BloggingContext())
            {
                Console.WriteLine(blogsdb.Blogs.Count());
                var b = new Blog {Topic = "Soup"};
                b.Posts.Add(new Post { Content = "Rice Soup" });
                b.Posts.Add(new Post { Content = "Tomato Soup" });
                blogsdb.Blogs.Add(b);

                Console.WriteLine(b.BlogId);
                blogsdb.SaveChanges();

                Console.WriteLine(b.BlogId);

                foreach (var post in blogsdb.Posts.Include(p => p.Blog) )
                {
                    Console.WriteLine(post.Blog.Topic);
                }

                Console.WriteLine(blogsdb.Blogs);
            }

        }
    }
}
