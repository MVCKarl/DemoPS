namespace Application.Validation
{
    public class ValidatorResult 
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }   
    }

    public class SuccessfulValidatorResult : ValidatorResult
    {
    }

    public class FailedValidatorResult : ValidatorResult
    {
        public FailedValidatorResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsValid = false;
        }
    }
}
