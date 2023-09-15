using Microsoft.EntityFrameworkCore;
using XYZCompany.Entities;

namespace XYZCompany.Repositories
{
    public class XYZCompanyContext : DbContext
    {
        public XYZCompanyContext(DbContextOptions<XYZCompanyContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Title> Titles { get; set; }
    }
}
