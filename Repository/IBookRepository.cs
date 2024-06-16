using ManageLibrary.Model;

namespace ManageLibrary.Repository;

public interface IBookRepository
{
    public void Create(Book book);
    public void Update(Book book);
    public void Delete(Book book);
    public List<Book> GetAll();
    public Book? GetById(Guid id);
}
