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

            if (s.Length != 10 && s.Length != 13)
            {
                BookInfo badISBN = new BookInfo("ISBN must be 10 or 13 characters in length");
                return badISBN;
            }

            if (s.Length == 13 && !ISBNChecksum(s))
            {
                BookInfo badISBN = new BookInfo("ISBN failed checksum test");
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
                    sum += GetIntFromStringPosition(isbn, i) * 3;
                }
                else
                {
                    sum += GetIntFromStringPosition(isbn, i);
                }
            }

            var mod = sum % 10;
            var checkSum = 10 - mod;

            return GetIntFromStringPosition(isbn, 12) == checkSum;

        }

        private int GetIntFromStringPosition(string baseString, int position)
        {
            return int.Parse(baseString.Substring(position, 1));
        }
    }
}