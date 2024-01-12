using System.Net;

namespace DesafioNetCore.Domain.Entities.Common
{
    public class ErrorResult
    {
        public List<string> Errors { get; set; }
        public string Exception { get; set; }
        public string ErrorId { get; set; }
        public int StatusCode { get; set; }
    }
}
