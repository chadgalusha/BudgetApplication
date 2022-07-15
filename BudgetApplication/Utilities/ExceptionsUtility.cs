using Serilog;

namespace BudgetApplication.Utilities
{
    public static class ExceptionsUtility
    {
        public static void LogInnerExceptionMessageIfExists(Exception e)
        {
            if (e.InnerException != null)
            {
                Log.Error("Inner Exception error: {e}", e.InnerException.Message);
            }
        }
    }
}
