namespace Monolithic.Architecture.API.Contracts.Common;

public interface IDataModel : IAuditTrail
{
    public string Id { get; set; }
}
