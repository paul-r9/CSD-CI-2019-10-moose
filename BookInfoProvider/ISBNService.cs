using System;
using System.Collections.Generic;

/*
 * This is an in-memory example of a BookInfoProvider.
 * It will be used as a Test Double to permit testing of ISBNFinder behavior
 * without having to invoke the actual remote BookInfoProvider
 * 
 */

namespace BookInfoProvider {
    public sealed class ISBNService : IBookInfoProvider {
        private static ISBNService instance = null;
        private static readonly object padlock = new object();
        private IDictionary<string, BookInfo> booksByIsbn10;
        private IDictionary<string, BookInfo> booksByIsbn13;

        ISBNService() {
            booksByIsbn10 = new Dictionary<String, BookInfo>();
            booksByIsbn13 = new Dictionary<String, BookInfo>();
            
            foreach (String[] book in books) {
                BookInfo bi = new BookInfo(book[0], book[1], book[2], book[3]);
                booksByIsbn10[bi.Isbn10] = bi;
                booksByIsbn13[bi.Isbn13] = bi;
            }

        }

        public static ISBNService Instance {
            get {
                lock (padlock);
                {
                    if (instance == null) {
                        instance = new ISBNService();
                    }

                    return instance;
                }
            }
        }

        string[][] books = new string[][] {
            new string[] {"97 Things Every Programmer Should Know", "Kevlin Henney",   "0596809484", "9780596809485"},
            new string[] {"Accelerate", "Forsgren, Humble, Kim",                       "1942788339", "9781942788331"},
            new string[] {"Pattern-Oriented SW Architecture Vol 1", "Frank Buschmann", "0471958697", "9780471958697"},
            new string[] {"Pattern-Oriented SW Architecture Vol 2", "Douglas Schmidt", "0471606952", "9780471606956"},
            new string[] {"Pattern-Oriented SW Architecture Vol 3", "Michael Kircher", "0478084525", "9780470845257"},
            new string[] {"Pattern-Oriented SW Architecture Vol 4", "Frank Buschmann", "0470059028", "9780470059029"},
            new string[] {"Pattern-Oriented SW Architecture Vol 5", "Frank Buschmann", "0471486485", "9780471486480"},
            new string[] {"Refactoring", "Martin Fowler",                              "0201485672", "9780201485677"},
            new string[] {"Refactoring 2nd Edition", "Martin Fowler",                  "0134757599", "9780134757599"},
            new string[] {"Test Driven Development by Example", "Kent Beck",           "0321146530", "9780321146533"},
            new string[] {"The Laws of Simplicity", "John Maeda",                      "0262134721", "9780262134729"},
            new string[] {"The Thief Lord", "Cornelia Funke",                          "043942089X", "9780439420891"},
            new string[] {"Working Effectively with Legacy Code", "Michael Feathers",  "0131177052", "9780131177055"},
            new string[] {"xUnit Test Patterns", "Gerard Meszaros",                    "0131495054", "9780131495050"},
        };
        
        public BookInfo retrieve(string isbn) {
            if (10 == isbn.Length) {
                if (booksByIsbn10.ContainsKey(isbn)) {
                    return booksByIsbn10[isbn];
                }
            }

            if (booksByIsbn13.ContainsKey(isbn)) {
                return booksByIsbn13[isbn];
            }

            return null;
        }
    }
}