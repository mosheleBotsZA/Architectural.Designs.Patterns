namespace Monolithic.Architecture.API.Data.Models.Users
{
    public class Company : DataModelBase
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Logo { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
    }
}