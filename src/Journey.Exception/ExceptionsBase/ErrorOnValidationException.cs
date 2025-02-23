namespace Journey.Exception.ExceptionsBase
{
    public class ErrorOnValidationException : JourneyException
    {
        private readonly IList<string> _errors;
        
        public ErrorOnValidationException(IList<string> message) : base(string.Empty)
        {
            _errors = message;
        }
    }
}
