using ManageLibrary.Model;

namespace ManageLibrary.Repository;

public class BookRepository : IBookRepository
{
    private List<Book> _books = [];

    public void Create(Book book)
    {
        _books.Add(book);
    }

    public void Delete(Book book)
    {
        var bookToDelete = _books.FirstOrDefault(b => b.Id == book.Id);

        if (bookToDelete != null)
            bookToDelete.DeletedAt = DateTime.Now;
    }

    public List<Book> GetAll()
    {
        return _books.Where(book => book.DeletedAt == null).ToList();
    }

    public Book? GetById(Guid id)
    {
        return _books.FirstOrDefault(book => book.Id == id && book.DeletedAt == null);
    }

    public void Update(Book book)
    {
        var existingBook = _books.FirstOrDefault(b => b.Id == book.Id && b.DeletedAt == null);
        _books.Remove(existingBook!);
        _books.Add(book);
    }
}
