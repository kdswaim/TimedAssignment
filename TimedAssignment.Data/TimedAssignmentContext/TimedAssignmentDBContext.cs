using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TimedAssignment.Data.Entities;

namespace TimedAssignment.Data.TimedAssignmentContext
{
    public class TimedAssignmentDBContext : IdentityDbContext
    {
        public TimedAssignmentDBContext(DbContextOptions<TimedAssignmentDBContext> options)
         : base(options)
         {

         }

        public DbSet<Hate> Hates {get; set;}

        public DbSet<Comment> Comments {get; set;}

        public DbSet<Reply> Replies {get; set;}

        public DbSet<Post> Posts {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}