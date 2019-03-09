namespace UserProjects.Common.Results
{
    public class Response
    {
        public bool Result { get; set; }
        public string Message { get; set; }
    }

    public class TokenResponse : Response
    {
        public string Token { get; set; }
    }

    public class ObjectResponse<TObject> : Response where TObject : class
    {
        public TObject Object { get; set; }
    }
}