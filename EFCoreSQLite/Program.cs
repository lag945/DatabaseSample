// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "https://www.pilotgaea.com.tw", Url2 = "123" });
db.Add(new Blog { Url = "https://www.pilotgaea.com.tw", Url2 = "456" });
db.Add(new Blog { Url = "https://www.pilotgaea.com.tw", Url2 = "789" });
db.Add(new Blog { Url = "https://www.pilotgaea.com.tw"});
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

Console.WriteLine($"blog count: {db.Blogs.Count()}");

// // Update
// Console.WriteLine("Updating the blog and adding a post");
// blog.Url = "https://devblogs.microsoft.com/dotnet";
// blog.Posts.Add(
//     new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
// db.SaveChanges();

// // Delete
// Console.WriteLine("Delete the blog");
// db.Remove(blog);
db.SaveChanges();