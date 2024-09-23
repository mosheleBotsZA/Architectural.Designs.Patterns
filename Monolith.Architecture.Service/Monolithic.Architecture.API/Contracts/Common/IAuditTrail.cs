namespace Monolithic.Architecture.API.Contracts.Common;

public interface IAuditTrail : ISoftDelete
{
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
    public string LastUserUpdate { get; set; }
}
