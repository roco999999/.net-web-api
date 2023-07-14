namespace WebApplication1.Models
{
    public class Response
    {
        public string Message { get; set; }

        public Door _door { get; set; }

        
        public Response(string message, Door door)
        {
            Message = message;
            _door = door;
        }
    }
}
