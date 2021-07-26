namespace AirLiquide_Test.Domain.Responses
{
    public abstract class BaseResponse<T>
    {
        protected BaseResponse(T resource)
        {
            Success = true;
            Resource = resource;
        }

        protected BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }

        public T Resource { get; private set; }
        public bool Success { get; private set; }
        public string Message { get; private set; }
    }
}