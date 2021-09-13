using System; 

namespace PDFManager.Core
{
    public class PDFDocument
    {
        public int ID { get; set; }
        public string DocumentDescription { get; set; }
        public string DocumentAuthor { get; set; }
        public byte[] DocumentBytes { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public DocumentVisibility DocumentVisibility { get; set; }
        public bool Archived { get; set; }
    }
}