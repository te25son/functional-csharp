using Examples.Chapter03;
using Functional;
using NUnit.Framework;

namespace Examples.Tests.Chapter03
{
    using static F;

    public sealed class SubscriberTests : TestFixture
    {
        [Test]
        public void SubscriberSendsCorrect_WhenNameIsGiven()
        {
            Test(
                arrange: _ =>
                {
                    var subscriberName = "John";

                    return (
                        Subscriber: new Subscriber { Name = subscriberName },
                        SubscriberName: subscriberName.ToUpper()
                    );
                },
                act: arrangeResult => SubscriberComponent.GreetingFor(arrangeResult.Subscriber),
                assert: (arrangeResult, actResult) => Assert.AreEqual($"Dear {arrangeResult.SubscriberName}", actResult)
            );
        }

        [Test]
        public void SubscriberSendsCorrectGreeting_WhenNameIsNotGiven()
        {
            Test(
                arrange: _ => new Subscriber { Name = null },
                act: arrangeResult => SubscriberComponent.GreetingFor(arrangeResult),
                assert: (arrangeResult, actResult) => Assert.AreEqual($"Dear subscriber", actResult)
            );
        }
    }
}
