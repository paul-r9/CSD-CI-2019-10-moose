using System;
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

        public bool ISBNChecksum(string isbn)
        {
            var sum = 0;
            for (var i = 0; i < isbn.Length-1; i++)
            {
                if (i % 2 == 1)
                {
                    sum += int.Parse(isbn.Substring(i,1)) * 3;
                }
                else
                {
                    sum += int.Parse(isbn.Substring(i,1));
                }
            }

            var mod = sum % 10;
            var checkSum = 10 - mod;

            return int.Parse(isbn.Substring(12, 1)) == checkSum;

        }
    }
}