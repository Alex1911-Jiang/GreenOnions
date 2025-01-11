namespace GreenOnions.NT.Base
{
    public class RestResult<T>(bool succeed, T? data, string message = "")
    {
        public bool Success { get; set; } = succeed;
        public T? Data { get; set; } = data;
        public string Message { get; set; } = message;
    }
}
