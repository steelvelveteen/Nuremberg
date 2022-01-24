using Microsoft.EntityFrameworkCore;
using Nuremberg.Models;

namespace Nurember.Data;

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