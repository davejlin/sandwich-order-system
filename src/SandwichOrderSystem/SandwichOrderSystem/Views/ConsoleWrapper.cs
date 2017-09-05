using System;

namespace SandwichOrderSystem.Views
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadInput(string prompt, bool forceToLowercase = false)
        {
            Console.WriteLine();
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            return forceToLowercase ? input.ToLower() : input;
        }

        public void ClearOutput()
        {
            Console.Clear();
        }

        public void Output(string message)
        {
            Console.Write(message);
        }

        public void Output(string format, params object[] arg)
        {
            Console.Write(format, arg);
        }

        public void OutputLine(string message, bool outputBlankLineBeforeMessage = true)
        {
            if (outputBlankLineBeforeMessage)
            {
                Console.WriteLine();
            }
            Console.WriteLine(message);
        }

        public void OutputLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }

        public void OutputBlankLine()
        {
            Console.WriteLine();
        }

        public void PromptToContinue()
        {
            OutputBlankLine();
            ReadInput(Constants.CONSOLE_PROMPT_TO_CONTINUE, false);
        }

        public void PromptInvalidCommand()
        {
            ClearOutput();
            OutputLine(Constants.CONSOLE_INVALID_COMMAND, true);
            PromptToContinue();
        }
    }
}
