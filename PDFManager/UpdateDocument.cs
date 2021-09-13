using PDFManager.Core;
using Microsoft.EntityFrameworkCore.Storage; 
using System; 

namespace PDFManager
{
    public class UpdateDocument
    {
        PDFDocument m_Document;

        public UpdateDocument(PDFDocument document)
        {
            m_Document = document;
        }

        /// <summary>
        /// Commit the updates for the document to the database 
        /// </summary>
        public void Update() 
        {
            using (PDFManagerContext context = new PDFManagerContext())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Update(m_Document);
                        context.SaveChanges();
                        transaction.Commit(); 
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message); 
                        throw; 
                    }
                }
            }
        }
    }
}