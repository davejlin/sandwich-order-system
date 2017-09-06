using System.Diagnostics;

namespace SandwichOrderSystemShared.Services
{
    public class ErrorHandler : IErrorHandler
    {
        public void HandleError(string error)
        {
            Debug.WriteLine(error);
        }
    }
}
