using Microsoft.EntityFrameworkCore; 
using Microsoft.Data.Sqlite; 

namespace PDFManager.Core
{
    public class PDFManagerContext : DbContext
    {
        // Models
        DbSet<PDFDocument> PDFDocuments { get; set; }

        // COntext overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqliteConnectionStringBuilder csBuilder = new SqliteConnectionStringBuilder();
            csBuilder.ForeignKeys = true;
            csBuilder.DataSource = "DocumentStore.db";
            optionsBuilder.UseSqlite(csBuilder.ConnectionString); 
        }
    }
}