using BackendEvaluation.Domain.Models.Base;

namespace BackendEvaluation.Domain.Models.Item;
public class Item:ModelBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
        
}