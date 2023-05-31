namespace BackendEvaluation.Domain.Models.Base;
public class ModelBase
{
    public int Id { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string CreatedUser { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? UpdatedUser { get; set; }
}
