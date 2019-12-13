using BookInfoProvider;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ISBN.Tests
{
    public class BookInfoTest
    {
        [Fact]
        public void BookInfo_Dash_Space_Are_Removed()
        {
            //string ISBN = "032 114-6530";

            //ISBNFinder sut = new ISBNFinder();
            //BookInfo actual = sut.lookup(ISBN);

            BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "03211-4 6530", "97803-211 46533");

            Assert.Equal("0321146530,9780321146533", expected.Isbn10 + "," + expected.Isbn13);
        }
    }
}
