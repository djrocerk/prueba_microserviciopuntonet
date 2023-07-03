using Microsoft.EntityFrameworkCore;

namespace prueba_microservicio.Data
{
    public class MyAppDbContext : MyAppDbContext
    {
        public DbSet<Flow> Flows { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Field> Fields { get; set; }

        public MyAppDbContext(DbSet<Flow> flows, DbSet<Step> steps, DbSet<Field> fields)
        {
            Flows = flows;
            Steps = steps;
            Fields = fields;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuraciones adicionales del modelo

            modelBuilder.Entity<Flow>()
                .HasMany(f => f.Steps)
                .WithOne(s => s.Flow)
                .HasForeignKey(s => s.FlowId);
        }

        public override bool Equals(object? obj)
        {
            return obj is MyAppDbContext context &&
                   EqualityComparer<DbSet<Flow>>.Default.Equals(Flows, context.Flows) &&
                   EqualityComparer<DbSet<Step>>.Default.Equals(Steps, context.Steps) &&
                   EqualityComparer<DbSet<Field>>.Default.Equals(Fields, context.Fields);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Flows, Steps, Fields);
        }
    }
}
