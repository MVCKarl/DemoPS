namespace Service
{
    public class ServiceResult
    {
        public bool Successful { get; set; }
        public string ValidationErrorMessage { get; set; }
        public string PowerShellResultMessage { get; set; }
    }

    public class ValidationError : ServiceResult
    {
        public ValidationError(string validationErrorMessage)
        {
            Successful = false;
            ValidationErrorMessage = validationErrorMessage;
        }
    }

    public class SuccessfulService : ServiceResult
    {
        public SuccessfulService(string powerShellResultMessage)
        {
            PowerShellResultMessage = powerShellResultMessage;
        }
    }
}
