using Monolithic.Architecture.API.Contracts.Common;

namespace Monolithic.Architecture.API.Data.Response
{
    public class Response<T> : IResponse where T : DTOModelBase
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public T Data { get; set; }
    }
}