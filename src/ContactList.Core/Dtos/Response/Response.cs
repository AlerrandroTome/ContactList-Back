namespace ContactList.Core.Dtos.Response
{
    public class Response<T>
    {
        public Response()
        {
            StatusCode = 200;
            AnErrorOcurred = false;
        }

        public int StatusCode { get; set; }
        public bool AnErrorOcurred { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }
    }
}
