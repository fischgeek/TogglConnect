using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public static class ConsoleShortcuts
    {
        /// <summary>
        /// Console.Clear();
        /// </summary>
        public static void cc() => Console.Clear();
        /// <summary>
        /// Console.WriteLine(text);
        /// </summary>
        /// <param name="text"></param>
        public static void cl(string text = "") => Console.WriteLine(text);
        public static void clt(string text = "")
        {
            var stamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cl($"[{stamp}] {text}");
        }
        /// <summary>
        /// Console.Write(text);
        /// </summary>
        /// <param name="text"></param>
        public static void cw(string text) => Console.Write(text);
        /// <summary>
        /// Clears the Console, writes a title (text) and appends the Bottom Options.
        /// </summary>
        /// <param name="text"></param>
        public static void ct(string text)
        {
            cc();
            cl(text.ToUpper());
            br();
        }
        /// <summary>
        /// Writes out the text as an error message.
        /// </summary>
        /// <param name="text"></param>
        public static void ce(string text)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            cl(text);
            Console.ResetColor();
        }
        /// <summary>
        /// Writes out the text as a success message.
        /// </summary>
        /// <param name="text"></param>
        public static void cs(string text)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            cl(text);
            Console.ResetColor();
        }
        /// <summary>
        /// Does a Console.Write(prompt) and returns the user input (lowered).
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>User's input (lowered)</returns>
        public static string rl(string prompt = "")
        {
            cw($"{prompt}: ");
            return Console.ReadLine().ToLower();
        }
        /// <summary>
        /// Creates a visual line break.
        /// </summary>
        public static void br() => cl("--------------------------------------------------");
        /// <summary>
        /// Writes the common Bottom Options.
        /// </summary>
        public static void bo()
        {
            cl();
            cl("b - Back to main operations");
            cl("s - Switch operation mode");
            cl("x - Exit");
            cl();
            cw("Option");
        }
        public static void ExitApp() => Environment.Exit(0);
    }
}
