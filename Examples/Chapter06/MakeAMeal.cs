using Functional;
using Functional.Either;
using System;

namespace Examples.Chapter06
{
    class MakeAMeal 
    {
        public Either<Reason, Unit> WakeUpEarly(Alarm alarm)
        {
            if (alarm.IsSet) return Unit.Value;
            else return new Reason("Didn't wake up early; alarm wasn't set.");
        }

        Func<Unit, Either<Reason, Ingredients>> ShopForIngredients;
        Func<Ingredients, Either<Reason, Food>> CookRecipe;

        Action<Food> EnjoyTogether;
        Action<Reason> ComplainAbout;
        Action OrderPizza;

        void Run()
        {
            var alarm = new Alarm(isSet: true);

            WakeUpEarly(alarm)
                .Bind(ShopForIngredients)
                .Bind(CookRecipe)
                .Match(
                    right: dish => EnjoyTogether(dish),
                    left: reason =>
                    {
                        ComplainAbout(reason);
                        OrderPizza();
                    }
                );
        }
    }

    public class Alarm
    {
        public bool IsSet { get; set; }

        public Alarm(bool isSet)
        {
            IsSet = isSet;
        }
    }


    class Reason 
    {
        private string Explanation { get; set; }

        public Reason(string explanation)
        {
            Explanation = explanation;
        }
    }

    class Ingredients 
    {
    }

    class Food 
    {
    }
}
