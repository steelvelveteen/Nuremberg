using Microsoft.EntityFrameworkCore;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}

public partial class ApplicationDbContext
{
    public DbSet<TestModel> TestModels { get; set; } = null!;
}