using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using PDFManager.Core;
using System; 

namespace PDFManager
{
    public class DeleteDocument
    {
        private IPDFDocument m_Document;

        public DeleteDocument(IPDFDocument document)
        {
            m_Document = document;
        }

        public void RemoveDocument()
        {
            // Guard
            if(m_Document is null)
            {
                throw new Exception("The document you are attempting to delete is null");
            }

            using (PDFManagerContext context = new PDFManagerContext())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    var result = context.PDFDocuments.FirstOrDefault(p => p.IdentificationString == m_Document.IdentificationString);
                    if(result is not null)
                    {
                        try
                        {
                            context.Remove(result);
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
}