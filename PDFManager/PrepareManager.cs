using PDFManager.Core; 
using Microsoft.EntityFrameworkCore; 

namespace PDFManager
{
    public static class PrepareManager
    {
        /// <summary>
        /// Prepares the PDF storage and retrieval manager for use. 
        /// NOTE: This should be called at the startup of your base project to ensure that
        /// the PDF manager's database has been created successfully, and that all migrations
        /// have been applied to the database file. 
        /// </summary>
        public static void InitializeSystem() 
        {
            using (PDFManagerContext context = new PDFManagerContext())
            {
                context.Database.Migrate(); 
            }
        }
    }
}