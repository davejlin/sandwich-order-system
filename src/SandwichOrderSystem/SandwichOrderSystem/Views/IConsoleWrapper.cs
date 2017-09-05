namespace SandwichOrderSystem.Views
{
    public interface IConsoleWrapper
    {
        string ReadInput(string prompt, bool forceToLowercase = false);
        void ClearOutput();
        void Output(string message);
        void Output(string format, params object[] arg);
        void OutputLine(string message, bool outputBlankLineBeforeMessage = true);
        void OutputLine(string format, params object[] arg);
        void OutputBlankLine();
    }
}