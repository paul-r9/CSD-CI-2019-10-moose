using BookInfoProvider;

namespace BookInfoProvider {

    public interface IBookInfoProvider {
        BookInfo retrieve(string ISBN);
    }
}