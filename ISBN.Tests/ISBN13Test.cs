﻿using System;
using System.Collections.Generic;
using System.Text;
using BookInfoProvider;
using Xunit;

namespace ISBN.Tests
{
    public class ISBN13Test
    {
        [Fact]
        public void ISBN13_CheckSum()
        {
            string ISBN = "9780470059029";

            ISBNFinder sut = new ISBNFinder();
            Assert.True(sut.ISBNChecksum(ISBN));

            
        }

        [Fact]
        public void ISBN_ShorterThan13Characters_ReturnsInvalidBookInfo()
        {
            //Arrange
            string shortISBN = "12345";

            //Act
            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(shortISBN);

            //Assert
            Assert.Equal("ISBN must be 10 or 13 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN_LongerThan13Characters_ReturnsInvalidBookInfo()
        {
            string longISBN = "123456789ABCEDF";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(longISBN);

            Assert.Equal("ISBN must be 10 or 13 characters in length", actual.Title);
        }

        [Fact]
        public void ISBN13_BookAvailableFromFinder()
        {
            string unknownISBN = "0553562614678";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(unknownISBN);

            Assert.Equal("Title not found", actual.Title);
        }

        [Fact]
        public void ISBN13_BookFound()
        {
            string ISBN = "9780596809485";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(ISBN);

            BookInfo expected = new BookInfo("97 Things Every Programmer Should Know", "Kevlin Henney", "0596809484", "9780596809485");
            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Fact]
        public void ISBN_CheckDashes ()
        {
            string ISBN = "978-0-262-13472-9";

            ISBNFinder sut = new ISBNFinder();
            BookInfo actual = sut.lookup(ISBN);

            //BookInfo expected = new BookInfo("Test Driven Development by Example", "Kent Beck", "0321146530", "9780321146533");
            Assert.Equal(13, actual.Isbn13.Length);
        }
    }
}

