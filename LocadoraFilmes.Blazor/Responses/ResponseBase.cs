namespace LocadoraFilmes.Blazor.Responses
{
    public class ResponseBase<T>
    {
        public T? Data { get; set; }
        public List<MessageResult>? MessageResults { get; set; }
        public bool IsValid { get; set; }

        public ResponseBase() { }


        public class MessageResult
        {
            public string Code { get; set; }
            public string Description { get; set; }

            public MessageResult() { }
        }
    }
}
