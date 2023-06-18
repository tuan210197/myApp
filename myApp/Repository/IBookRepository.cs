using myApp.Data;
using myApp.Model;

namespace myApp.Repository
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> getAllBookAsync();
        public Task<BookModel> getBookAsync(int id);
        public Task<int> addBookAsync(BookModel bookModel);
        public Task updateBookAsync(int id, BookModel bookModel);
        public Task deleteBookAsync(int id);
    }
}
