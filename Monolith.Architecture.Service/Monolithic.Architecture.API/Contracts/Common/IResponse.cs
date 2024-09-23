namespace Monolithic.Architecture.API.Contracts.Common
{
    public interface IResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}