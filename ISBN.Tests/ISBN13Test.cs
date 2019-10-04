using System;
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

    }
}
