﻿using BookInfoProvider;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ISBN.Tests
{
    public class ISBNServiceTest
    {
        [Fact]
        public void BookInfo_Dash_Space_Are_Removed()
        {

            ISBNService expected = ISBNService.Instance;

            Assert.Equal("0321146530", expected.NormalizeISBN("0321-1465 30"));
        }

        [Theory]
        [InlineData("0321 - 1465 30")]
        public void ISBNService_Validate_Numbers_only(string isbn)
        {
  
            ISBNService expected = ISBNService.Instance;
            string normalizedIsbn = expected.NormalizeISBN(isbn);
            
            Assert.True(expected.IsISBNAllDigits(normalizedIsbn));
        }

        [Theory]
        [InlineData("0321 - 1465A 30")]
        public void ISBNService_Validate_Numbers_only_with_letter(string isbn)
        {

            ISBNService expected = ISBNService.Instance;
            string normalizedIsbn = expected.NormalizeISBN(isbn);

            Assert.False(expected.IsISBNAllDigits(normalizedIsbn));
        }

        [Theory]
        [InlineData("0321 - 1465 30")]
        public void ISBNService_Validate_ISNB10_Length(string isbn)
        {

            ISBNService expected = ISBNService.Instance;
            string normalizedIsbn = expected.NormalizeISBN(isbn);

            Assert.True(expected.IsISBN10Size(normalizedIsbn));
        }

        [Theory]
        [InlineData("0321 - 1465 30121")]
        public void ISBNService_Validate_ISNB13_Length(string isbn)
        {

            ISBNService expected = ISBNService.Instance;
            string normalizedIsbn = expected.NormalizeISBN(isbn);

            Assert.True(expected.IsISBN13Size(normalizedIsbn));
        }
    }
}
