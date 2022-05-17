namespace Infrastructure2.Powershell
{
    public interface IPowerShellOperations
    {
        public string ExecuteScript(string name, string parameters);
    }

    public class PowerShellOperations : IPowerShellOperations
    {
        public string ExecuteScript(string name, string parameters)
        {
            return "";
        }
    }
}
