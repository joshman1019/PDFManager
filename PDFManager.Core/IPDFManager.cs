namespace PDFManager.Core
{
    public interface IPDFDocument
    {
        int ID { get; set; }
        string IdentificationString { get; set; }
        string DocumentDescription { get; set; }
        string DocumentAuthor { get; set; }
        byte[] DocumentBytes { get; set; }
        DocumentStatus DocumentStatus { get; set; }
        DocumentVisibility DocumentVisibility { get; set; }
        bool Archived { get; set; }
    }
}