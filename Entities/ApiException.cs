namespace ToursApi.Entities
{
    public class ApiException
    {
        public ApiException(int statusCode, string? message = null, string? details = null)
        {
            StatusCode = statusCode;
            Message = message ?? null;
            Details = details ?? null;
        }

        public int? StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Details { get; set; }
    }
}