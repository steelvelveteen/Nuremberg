using Microsoft.EntityFrameworkCore;
using Nuremberg.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}

public partial class ApplicationDbContext : DbContext
{
    public DbSet<TestModel> TestModels { get; set; } = null!;
}

public partial class ApplicationDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TestModel>().HasData(
            new TestModel
            {
                Id = Guid.NewGuid(),
                TestModelName = "First name",
                TestModelOtherProp = "Some other property name"
            },
            new TestModel
            {
                Id = Guid.NewGuid(),
                TestModelName = "Sec name",
                TestModelOtherProp = "Some sec property name"
            },
            new TestModel
            {
                Id = Guid.NewGuid(),
                TestModelName = "Tres name",
                TestModelOtherProp = "Some tres property name"
            }
        );
    }
}