namespace ProjetoCompAplicada.CSharp.Models
{
    public class ResponseBase<T>
    {
        public bool Success { get; init; }
        public T? Data { get; init; }
        public string? Message { get; init; }
        public List<string> Errors { get; init; } = new();

        public static ResponseBase<T> Ok(T data, string? message = null) =>
            new ResponseBase<T>
            {
                Success = true,
                Data = data,
                Message = message
            };

        public static ResponseBase<T> Fail(IEnumerable<string> errors, string? message = null) =>
            new ResponseBase<T>
            {
                Success = false,
                Errors = errors.ToList(),
                Message = message
            };
    }
}
