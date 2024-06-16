namespace ManageLibrary.Communication.Requests;

public class RequestRegisterBookJson
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Genrer { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
