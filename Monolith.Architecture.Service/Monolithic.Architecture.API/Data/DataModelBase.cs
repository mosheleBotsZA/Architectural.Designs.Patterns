using Monolithic.Architecture.API.Contracts.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monolithic.Architecture.API.Data;

public class DataModelBase : IDataModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
    public string LastUserUpdate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}
