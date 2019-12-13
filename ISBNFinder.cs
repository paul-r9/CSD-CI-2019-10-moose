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
            
            if (ISBN.Length != 10) {
                BookInfo badISBN = new BookInfo("ISBN must be 10 characters in length");
                return badISBN;
            }

            BookInfo bookInfo = isbnService.retrieve(ISBN);
            
            if (null == bookInfo) {
                return new BookInfo("Title not found");
            }
            
            return bookInfo;
        }

        public bool checkISBN13(string ISBN)
        {
            var checkSum = 0;
            for (var i = 0; i < ISBN.Length - 1; i += 2)
            {
                checkSum += ISBN[i] - '0';
            }
            for (var i = 1; i < ISBN.Length - 1; i += 2)
            {
                checkSum += 3 * (ISBN[i] - '0');
            }

            checkSum = (10 - (checkSum % 10)) % 10;

            return checkSum == (ISBN[12] - '0');
        }
    }
}