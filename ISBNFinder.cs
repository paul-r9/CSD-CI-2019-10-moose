using BookInfoProvider;

namespace ISBN {
    public class ISBNFinder {
        private IBookInfoProvider isbnService = null;

        public ISBNFinder() : this(ISBNService.Instance) {
        }

        public ISBNFinder(IBookInfoProvider bookInfoProvider) {
            isbnService = bookInfoProvider;
        }
        
        public BookInfo lookup(string ISBN) {

            string s = CheckFormat(ISBN);

            if (s.Length != 10 && s.Length != 13) {
                BookInfo badISBN = new BookInfo("ISBN must be 10 or 13 characters in length");
                return badISBN;
            }

            BookInfo bookInfo = isbnService.retrieve(s);
            
            if (null == bookInfo) {
                return new BookInfo("Title not found");
            }
            
            return bookInfo;
        }

        public string CheckFormat(string ISBN)
        {
            string s = ISBN.Replace("-", "").Replace(" ", "");
            return s;
        }
    }
}