using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Diagnostics

public class BloggingContext : DbContext
{
    private static readonly bool[] m_Migrated = {false};
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        //var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = System.AppContext.BaseDirectory;//Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
        Database.Migrate();
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public string Url2 { get; set; } = "";

    public List<Post> Posts { get; } = new();
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}