namespace Book_Application.Shared.Exceptions
{
    public class BaseCommandException : Exception
    {
        public BaseCommandException() { }
        public BaseCommandException(string message) : base(message)
        { }
    }

}
