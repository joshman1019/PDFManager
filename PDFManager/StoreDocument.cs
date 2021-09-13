using Microsoft.EntityFrameworkCore.Storage;
using PDFManager.Core; 
using System; 

namespace PDFManager
{
    public class CreateDocument
    {
        private IPDFDocument m_Document; 
        public CreateDocument(IPDFDocument document)
        {
            m_Document = document; 
        }

        /// <summary>
        /// Stores the PDF Document into the database
        /// NOTE: You will need to store the document as a byte[] in the DocumentBytes
        /// property. 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Store() 
        {
            using (PDFManagerContext context = new PDFManagerContext())
            {
                // Guard
                if(m_Document is null)
                {
                    throw new Exception("The document that you are attempting to store is null"); 
                }
                
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