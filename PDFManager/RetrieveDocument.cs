using PDFManager.Core; 
using System.Linq; 

namespace PDFManager
{
    public class RetrieveDocument
    {
        private string m_IdentificationString;

        public RetrieveDocument(string identificationString)
        {
            m_IdentificationString = identificationString;
        }

        /// <summary>
        /// Retrieves the PDF Document based on the identification string
        /// NOTE: If no document is returned, a blank PDF document object will be returned
        /// with an empty identification string
        /// </summary>
        /// <returns></returns>
        public IPDFDocument Retrieve()
        {
            using (PDFManagerContext context = new PDFManagerContext())
            {
                var result = context.PDFDocuments.FirstOrDefault(p => p.IdentificationString == m_IdentificationString); 
                if(result is not null)
                {
                    return result; 
                }
                else 
                {
                    return new PDFDocument()
                    {
                        IdentificationString = "",
                    }; 
                }
            }
        }
    }
}
