using Microsoft.EntityFrameworkCore.Storage;
using PDFManager.Core; 
using System; 

namespace PDFManager
{
    public class CreateDocument
    {
        private PDFDocument m_Document; 
        public CreateDocument(PDFDocument document)
        {
            m_Document = document; 
        }

        public void Store() 
        {
            using (PDFManagerContext context = new PDFManagerContext())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Add(m_Document);
                        context.SaveChanges();
                        transaction.Commit(); 
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                        throw; 
                    }
                }
            }
        }
    }
}