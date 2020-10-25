using Functional;
using Functional.Either;
using System;

namespace Examples.Chapter06
{
    using static F;

    public class Recruitment_OptionExample
    {
        Func<Candidate, bool> IsEligible;
        Func<Candidate, Option<Candidate>> TechTest;
        Func<Candidate, Option<Candidate>> Interview;

        Option<Candidate> Recruit(Candidate candidate) =>
            Some(candidate)
                .Where(IsEligible)
                .Bind(TechTest)
                .Bind(Interview);
    }

    public class Recruitment_EitherExample
    {
        Func<Candidate, bool> IsEligible;
        Func<Candidate, Either<Rejection, Candidate>> TechTest;
        Func<Candidate, Either<Rejection, Candidate>> Interview;

        Either<Rejection, Candidate> CheckEligibility(Candidate candidate)
        {
            if (IsEligible(candidate)) return candidate;
            else return new Rejection("Not eligible");
        }

        Either<Rejection, Candidate> Recruit(Candidate candidate) =>
            Right(candidate)
                .Bind(CheckEligibility)
                .Bind(TechTest)
                .Bind(Interview);
    }

    public class Candidate 
    {
    }

    public class Rejection
    {
        private string Reason;

        public Rejection(string reason)
        {
            Reason = reason;
        }
    }
}
