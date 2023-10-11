namespace ShopDemo.Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }
    
    public DateTime? DateCreated { get; set; }
    
    public DateTime? DateModified { get; set; }
}