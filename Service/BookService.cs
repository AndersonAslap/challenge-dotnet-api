using ManageLibrary.Communication.Requests;
using ManageLibrary.Model;
using ManageLibrary.Repository;

namespace ManageLibrary.Service;

public class BookService(IBookRepository bookRepository) : IBookService
{

    private readonly IBookRepository _bookRepository = bookRepository;

    public void Create(RequestRegisterBookJson input)
    {
        var book = new Book
        {
            Title = input.Title,
            Author = input.Author,
            Genrer = input.Genrer,  
            Price = input.Price,
            Quantity = input.Quantity
        };

        _bookRepository.Create(book);
    }

    public void Delete(Book book)
    {
        _bookRepository.Delete(book);
    }

    public void Update(Book book, RequestUpdateBookJson input)
    {
        book.Title = input.Title;   
        book.Author = input.Author;
        book.Genrer = input.Genrer;
        book.Price = input.Price;
        book.Quantity = input.Quantity; 
        book.UpdatedAt = DateTime.Now;

        _bookRepository.Update(book);
    }
}
