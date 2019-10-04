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