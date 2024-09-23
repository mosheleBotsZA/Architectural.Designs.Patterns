namespace Monolithic.Architecture.API.Data.DTO
{
    public class ApplicationDTO : DTOModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime AvailableDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public string Banner { get; set; }
        public string CompanyId { get; set; }
        public string CategoryId { get; set; }
        public string IndustryId { get; set; }
        public string LocationId { get; set; }
    }
}