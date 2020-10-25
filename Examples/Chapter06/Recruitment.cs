using Functional;
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

    public class Candidate 
    {
    }
}
