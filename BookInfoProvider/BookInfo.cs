namespace BookInfoProvider {
    public class BookInfo {
        private string title;
        private string author;
        private string ISBN10;
        private string ISBN13;

        public string Title => title;

        public string Author => author;

        public string Isbn10 => ISBN10;

        public string Isbn13 => ISBN13;

        public BookInfo(string title, string author, string ISBN10, string ISBN13) {
            this.title = title;
            this.author = author;
            this.ISBN10 = ISBN10;
            this.ISBN13 = ISBN13;
        }
        
        public BookInfo(string title) :
            this(title, null, null, null) {
        }

        public override string ToString() {
            return Title + ", " + Author + " - " + ISBN10 + ", " + ISBN13; 
        }
    }
}