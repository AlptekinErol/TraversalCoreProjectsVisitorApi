using Microsoft.EntityFrameworkCore;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.DAL.Context
{
    public class VisitorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ALPTEKIN\\SQLEXPRESS;initial catalog=TraversalDbApi;integrated security=true"); // db connection established
        }

        public  DbSet<Visitor>? Visitors { get; set; }
    }
}
