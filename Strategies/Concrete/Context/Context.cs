using System;
using study.Repositories.Interface;
using study.Strategies.Concrete.Interface;

namespace study.Strategies.Concrete.Context;

	public class Context
	{
    private IStrategy _strategy;

    public Context ()
    {

    }

    public Context(IStrategy strategy)
    {
        _strategy = strategy;
    }

    // here we can replace the current or default strategy if we choose
    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void CarryOutWork()
    {
        Console.WriteLine("Context: Carrying out Sorting Work");
        var myResult = _strategy
            .PerformAlgorithm(new List<string>
            {
            "the",
            "boy",
            "is",
            "leaving"
            });

        Console.WriteLine(String.Join(",", myResult));
    }

}

