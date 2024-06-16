using ManageLibrary.Communication.Requests;
using ManageLibrary.Communication.Responses;
using ManageLibrary.Repository;
using ManageLibrary.Service;
using Microsoft.AspNetCore.Mvc;

namespace ManageLibrary.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private static readonly IBookRepository _bookRepository = new BookRepository();
    private readonly IBookService _bookService = new BookService(_bookRepository);

    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseGetBookJson>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult GetAll()
    {
        try
        {
            var books = _bookRepository.GetAll();
            return Ok(books);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseGetBookJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(string id)
    {
        try
        {
            var book = _bookRepository.GetById(new Guid(id));

            if (book == null)
                return NotFound();

            return Ok(book);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }  
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult Create(RequestRegisterBookJson input)
    {
        try
        {
            _bookService.Create(input);
            return Created();
        }
        catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Update(string id, RequestUpdateBookJson input)
    {
        try
        {
            var book = _bookRepository.GetById(new Guid(id));

            if (book == null)
                return NotFound();

            _bookService.Update(book, input);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Remove(string id)
    {
        try
        {
            var book = _bookRepository.GetById(new Guid(id));
            
            if (book == null)
                return NotFound();

            _bookService.Delete(book);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
