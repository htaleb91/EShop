using CukurovaLibrary.Entities.Domain;

namespace EShop.Models
{
    public class BookSearchModel
    {
        public string Title { get; set; }
        public string Publisher { get; set; }

        public string BarCode { get; set; }
        public int AuthorId  { get; set; }
        public int BookId { get; set; }
        public IList<Book> Books { get; set; }

    }
}
