namespace Product.Manager.Logic.Utils;

public class ManagerHttpResponse<T>
{
    public ResponseStates Status { get; set; }
    public string Errors { get; set; }
    public T Data { get; set; }
}
