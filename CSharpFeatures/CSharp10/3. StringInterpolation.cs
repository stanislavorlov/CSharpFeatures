using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeatures.CSharp10
{
    internal class StringInterpolation
    {
        // Interpolation of const string
        const string constStrFirst = "FirstString";
        const string constStrSecond = $"{constStrFirst} SecondString";
    }

    [InterpolatedStringHandler]
    public ref struct LogInterpolatedStringHandler
    {
        StringBuilder builder;

        public LogInterpolatedStringHandler(int literalLength, int formattedCount)
        {
            builder = new StringBuilder(literalLength);
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
        }

        public void AppendLiteral(string s)
        {
            Console.WriteLine($"\tAppendLiteral called: {{{s}}}");

            builder.Append(s);
            Console.WriteLine($"\tAppended the literal string");
        }

        public void AppendFormatted<T>(T t)
        {
            Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");

            builder.Append(t?.ToString());
            Console.WriteLine($"\tAppended the formatted object");
        }

        internal string GetFormattedText() => builder.ToString();
    }
}
