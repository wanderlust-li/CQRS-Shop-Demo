using System.Net;

namespace ShopDemo.Domain.Entities;

public class APIResponse
{
    public APIResponse()
    {
        ErrorMessages = new List<string>();
    }
    public HttpStatusCode StatusCode { get; set; }
    
    public bool IsSuccess { get; set; } = true;
    
    public List<string> ErrorMessages { get; set; }
    
    public object Result { get; set; }
}