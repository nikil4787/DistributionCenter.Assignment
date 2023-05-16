namespace DistributionCenter.Models
{
    public class Response
    {
        public Response(string message)
        {
            Message = message;
            IsSuccess = true;
            Exception = null;
        }

        public Response(Exception ex)
        {
            Exception = ex;
            IsSuccess = false;
        }

        public string Message { get;private set; }
        public bool IsSuccess { get;private set; }
        public Exception? Exception { get; set; }
    }
}