using Functional;
using Functional.Either;
using System;

namespace Examples.Chapter06
{
    class MakeAMeal 
    {
        Func<Either<Reason, Unit>> WakeUpEarly;
        Func<Unit, Either<Reason, Ingredients>> ShopForIngredients;
        Func<Ingredients, Either<Reason, Food>> CookRecipe;

        Action<Food> EnjoyTogether;
        Action<Reason> ComplainAbout;
        Action OrderPizza;

        void Run()
        {
            WakeUpEarly()
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

    class Reason 
    {
    }

    class Ingredients 
    {
    }

    class Food 
    {
    }
}
