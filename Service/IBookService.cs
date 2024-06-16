using ManageLibrary.Communication.Requests;
using ManageLibrary.Model;

namespace ManageLibrary.Service;

public interface IBookService
{
    public void Create(RequestRegisterBookJson input);
    public void Update(Book book, RequestUpdateBookJson input);
    public void Delete(Book book);
}
