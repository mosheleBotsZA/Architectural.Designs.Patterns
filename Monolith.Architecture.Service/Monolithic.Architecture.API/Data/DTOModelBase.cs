namespace Monolithic.Architecture.API.Data
{
    public class DTOModelBase
    {
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}