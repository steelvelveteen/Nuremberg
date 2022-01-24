using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nuremberg.Models;

namespace Nuremberg.Data;

public partial class ApplicationDbContext : IdentityDbContext
{
    public DbSet<TestModel> TestModels { get; set; } = null!;
}