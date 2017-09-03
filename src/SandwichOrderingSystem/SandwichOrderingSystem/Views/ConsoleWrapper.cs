using System;

namespace SandwichOrderingSystem.Views
{
    public class ConsoleWrapper
    {
        public static string ReadInput(string prompt, bool forceToLowercase = false)
        {
            Console.WriteLine();
            Console.Write(prompt);
            string input = Console.ReadLine();
            return forceToLowercase ? input.ToLower() : input;
        }

        public static void ClearOutput()
        {
            Console.Clear();
        }

        public static void Output(string message)
        {
            Console.Write(message);
        }

        public static void Output(string format, params object[] arg)
        {
            Console.Write(format, arg);
        }

        public static void OutputLine(string message, bool outputBlankLineBeforeMessage = true)
        {
            if (outputBlankLineBeforeMessage)
            {
                Console.WriteLine();
            }
            Console.WriteLine(message);
        }

        public static void OutputLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }

        public static void OutputBlankLine()
        {
            Console.WriteLine();
        }
    }
}
