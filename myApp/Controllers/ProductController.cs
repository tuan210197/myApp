using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myApp.Model;
using myApp.Repository;

namespace myApp.Controllers
{
    [Route("/api/[controller]/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public ProductController(IBookRepository bookRepository) {
        
        _bookRepo = bookRepository;

        }
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllBook() {

            try
            {
                return Ok(await _bookRepo.getAllBookAsync());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getOne")]
        public async Task<IActionResult> getBookById(int id)
        {
            var book = await _bookRepo.getBookAsync(id);

            return book == null ? NotFound() : Ok(book);

        }

        [HttpPost]
        [Route("createNew")]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            try
            {
                var newBookId = await _bookRepo.addBookAsync(bookModel);
                var book = await _bookRepo.getBookAsync(newBookId);
                return book == null ? NotFound() : Ok(book);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> updateBook(int id, BookModel bookModel)
        {
            await _bookRepo.updateBookAsync(id, bookModel);
            return Ok();
        }
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> deleteBook([FromRoute] int id)
        {
            await _bookRepo.deleteBookAsync(id);
            return Ok();

        }
    
    }
}
