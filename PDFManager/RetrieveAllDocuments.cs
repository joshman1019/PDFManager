using System.Collections.Generic; 
using PDFManager.Core; 

namespace PDFManager
{
    public static class RetrieveAllDocuments
    {
        /// <summary>
        /// Retrieves a list of all stored PDF documents
        /// </summary>
        /// <returns></returns>
        public static List<PDFDocument> Retrieve()
        {
            using (PDFManagerContext context = new PDFManagerContext())
            {
                return new List<PDFDocument>(context.PDFDocuments);
            }
        }
    }
}