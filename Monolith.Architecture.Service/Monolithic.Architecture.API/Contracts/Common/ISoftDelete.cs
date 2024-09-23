namespace Monolithic.Architecture.API.Contracts.Common;

public interface ISoftDelete
{
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}
