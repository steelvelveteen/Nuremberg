using Microsoft.EntityFrameworkCore;
using Nuremberg.Models;

namespace Nuremberg.Data;

public partial class ApplicationDbContext : DbContext
{
    public DbSet<TestModel> TestModels { get; set; } = null!;
}