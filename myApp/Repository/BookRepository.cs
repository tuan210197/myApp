using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myApp.Data;
using myApp.Model;

namespace myApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper) {
            _context =  context;
            _mapper = mapper;
        }
        public async Task<int> addBookAsync(BookModel bookModel)
        {
            var newBook = _mapper.Map<Book>(bookModel);
            _context.Books!.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task deleteBookAsync(int id)
        {
            var deleteBook = _context.Books!.SingleOrDefault(book => book.Id == id);
            if(deleteBook != null)
            {
                _context.Books!.Remove(deleteBook);
                await _context.SaveChangesAsync() ;
            }
        }

        public async Task<List<BookModel>> getAllBookAsync()
        {
            var book = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookModel>>(book);
        }

        public async Task<BookModel> getBookAsync(int id)
        {
            var book = await _context.Books!.FindAsync(id);
            return _mapper.Map<BookModel>(book);    
        }

        public async Task updateBookAsync(int id, BookModel bookModel)
        {
            if(id == bookModel.Id) {
                var updateBook = _mapper.Map<Book>(bookModel);
                _context.Books!.Update(updateBook);
                await _context.SaveChangesAsync();

            }
        }
    }
}
