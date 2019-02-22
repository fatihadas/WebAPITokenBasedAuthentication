using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiOAuth.Models
{
    public class User2Context : DbContext
    {
        public User2Context()
        : base("User2Context")
        {
        }
        public DbSet<User> Users { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Article> Articles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // İlişkileri kuruyoruz one-to-many olarak.
            //modelBuilder.Entity<Article>()
            //.HasRequired<Category>(x => x.Category)
            //.WithMany(x => x.Articles)
            //.HasForeignKey(x => x.CategoryId);
            //modelBuilder.Entity<Article>()
            //.HasRequired<User>(x => x.User)
            //.WithMany(x => x.Articles)
            //.HasForeignKey(x => x.UserId);
            //base.OnModelCreating(modelBuilder);
        }
    }
}