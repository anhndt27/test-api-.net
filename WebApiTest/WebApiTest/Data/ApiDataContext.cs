using Microsoft.EntityFrameworkCore;
using WebApiTest.Model;

namespace WebApiTest.Data
{
    public class ApiDataContext :DbContext

    {
        
        public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options)
        { 
        }
        public DbSet<StudentClass> Student { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
            // Use Fluent API to configure  
  
            // Map entities to tables  
            modelBuilder.Entity<Class>().ToTable("Class");  
            modelBuilder.Entity<StudentClass>().ToTable("Student");  
  
            // Configure Primary Keys  
            modelBuilder.Entity<Class>().HasKey(ug => ug.Id).HasName("PK_Class");  
            modelBuilder.Entity<StudentClass>().HasKey(u => u.Id).HasName("PK_Student");  
  
            // Configure indexes  
            modelBuilder.Entity<Class>().HasIndex(p => p.Name).IsUnique().HasDatabaseName("Idx_Name");  
            modelBuilder.Entity<StudentClass>().HasIndex(u => u.Name).HasDatabaseName("Idx_Name");  
            modelBuilder.Entity<StudentClass>().HasIndex(u => u.Address).HasDatabaseName("Idx_Address");  
  
            // Configure columns  
            modelBuilder.Entity<Class>().Property(ug => ug.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();  
            modelBuilder.Entity<Class>().Property(ug => ug.Name).HasColumnType("nvarchar(100)").IsRequired();  
            modelBuilder.Entity<Class>().Property(ug => ug.CreationDateTime).HasColumnType("datetime").IsRequired();  
            modelBuilder.Entity<Class>().Property(ug => ug.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);  
  
            modelBuilder.Entity<StudentClass>().Property(u => u.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();  
            modelBuilder.Entity<StudentClass>().Property(u => u.Name).HasColumnType("nvarchar(50)").IsRequired();  
            modelBuilder.Entity<StudentClass>().Property(u => u.Address).HasColumnType("nvarchar(50)").IsRequired();  
            modelBuilder.Entity<StudentClass>().Property(u => u.StudentClassId).HasColumnType("int").IsRequired();  
            modelBuilder.Entity<StudentClass>().Property(u => u.CreationDateTime).HasColumnType("datetime").IsRequired();  
            modelBuilder.Entity<StudentClass>().Property(u => u.LastUpdateDateTime).HasColumnType("datetime").IsRequired(false);  
  
            // Configure relationships  
            modelBuilder.Entity<StudentClass>().HasOne<Class>().WithMany().HasPrincipalKey(ug => ug.Id).HasForeignKey(u => u.StudentClassId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Class_StudentClassId");  
        }  
        public DbSet<WebApiTest.Model.Class> Class { get; set; }
    }
}
