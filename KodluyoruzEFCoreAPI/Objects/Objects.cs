using System;
using System.Collections.Generic;
using KodluyoruzEFCoreAPI.DAL.Entities.Core;

namespace KodluyoruzEFCoreAPI.Objects
{
    public class Blog : IEntity
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public int slug { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post : IEntity
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
