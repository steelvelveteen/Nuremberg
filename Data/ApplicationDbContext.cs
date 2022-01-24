using Microsoft.EntityFrameworkCore;

namespace Nuremberg.Data;
public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}
