using Microsoft.EntityFrameworkCore;

namespace Template.Models
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions<TemplateContext> options)
            : base(options)
        {
        }

        public DbSet<Placeholder> Placeholders { get; set; }
    }
}