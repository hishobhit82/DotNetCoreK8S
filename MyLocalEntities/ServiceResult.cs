namespace MyLocalEntities
{
    public class ServiceResult<T>
    {
        public T[] Result { get; set; }
        public string Exception { get; set; }
        public ServiceResult(T[] result)
        {
            Result = result;
            Exception = string.Empty;
        }
        public ServiceResult(string exceptionMessage)
        {
            Result = Array.Empty<T>();
            Exception = exceptionMessage;
        }

        public ServiceResult(Exception exception) : this(exception.Message)
        {
        }
    }
}
