using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public static class ColorConsole
    {
        private static object _MessageLock = new object();

        /// <summary>
        /// Writes the provided text in a line in standard white.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <param name="args">An array of objects to write using format.</param>
        public static void WriteLine(string text, params object[] args)
        {
            WriteLine(ConsoleColor.White, text, args);
        }

        /// <summary>
        /// Writes a full line to console with a chosen foreground color
        /// </summary>
        /// <param name="color">The foreground color.</param>
        /// <param name="text">The text to write.</param>
        /// <param name="args">An array of objects to write using format.</param>
        public static void WriteLine(ConsoleColor color, string text, params object[] args)
        {
            lock (_MessageLock)
            {
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.WriteLine(text, args);
                Console.ForegroundColor = currentColor;
            }
            Console.ResetColor();
        }

        public static void Write(ConsoleColor color, int number, params object[] args)
        {
            Write(color, $"{number}", args);
        }

        /// <summary>
        /// Writes to console with a chosen foreground color
        /// </summary>
        /// <param name="color">The foreground color.</param>
        /// <param name="text">The text to write.</param>
        /// <param name="args">An array of objects to write using format.</param>
        public static void Write(ConsoleColor color, string text, params object[] args)
        {
            lock (_MessageLock)
            {
                ConsoleColor currentColor = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.Write(text, args);
                Console.ForegroundColor = currentColor;
            }
            Console.ResetColor();
        }

        ///// <summary>
        ///// Using null puts the color back to default
        ///// </summary>
        ///// <param name="inputs">Write("how about ", ConsoleColor.Red, "red", null, " text or how about ", ConsoleColor.Green, "green", null, " text");</param>
        ///// <remarks>https://stackoverflow.com/a/54123238/132639</remarks>
        //public static void Write(params object[] inputs)
        //{
        //    foreach (var item in inputs)
        //    {
        //        if (item == null)
        //        {
        //            Console.ResetColor();
        //        }
        //        else if (item is ConsoleColor)
        //        {
        //            Console.ForegroundColor = (ConsoleColor)item;
        //        }
        //        else
        //        {
        //            Console.Write(item.ToString());
        //        }
        //    }
        //}

        ///// <summary>
        ///// Using null puts the color back to default
        ///// </summary>
        ///// <param name="inputs">Write("how about ", ConsoleColor.Red, "red", null, " text or how about ", ConsoleColor.Green, "green", null, " text");</param>
        ///// <remarks>https://stackoverflow.com/a/54123238/132639</remarks>
        //public static void WriteLine(params object[] inputs)
        //{
        //    Write(inputs + "\r\n");
        //}
    }
}