using Functional;
using System.Text.RegularExpressions;

namespace Exercises.Chapter03
{
    using static F;
    using static System.Console;

    public class Email
    {
        static readonly Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        private string Value { get; }

        private Email(string value) => Value = value;

        public static Option<Email> Create(string s) =>
            regex.IsMatch(s)
                ? Some(new Email(s))
                : None;

        public static implicit operator string(Email email) => email.Value;
    }

    public static class EmailExample
    {
        public static void Run()
        {
            var email = Email.Create("email");
            WriteLine(email.Match(() => "Email not here", e => $"The email is {e}"));
        }
    }
}
