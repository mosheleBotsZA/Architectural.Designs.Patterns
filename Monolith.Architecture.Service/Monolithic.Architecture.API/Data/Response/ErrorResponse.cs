using Monolithic.Architecture.API.Contracts.Common;

namespace Monolithic.Architecture.API.Data.Response
{
    public class ErrorResponse : IResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
    }
}