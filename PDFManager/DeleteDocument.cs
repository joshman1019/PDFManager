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

        public void RemoveDocument(string identificationString)
        {
            using (PDFManagerContext context = new PDFManagerContext())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    var result = context.PDFDocuments.FirstOrDefault(p => p.IdentificationString == identificationString);
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