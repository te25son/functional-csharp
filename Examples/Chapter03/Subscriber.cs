using Functional;

namespace Examples.Chapter03
{
    public class Subscriber
    {
        public Option<string> Name { get; set; }

        public string Email { get; set; }

        public string GreetingFor(Subscriber subscriber) =>
            subscriber.Name.Match(
                () => "Dear subscriber",
                (name) => $"Dear {name.ToUpper()}");
    }
}
