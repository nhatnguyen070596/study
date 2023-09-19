using System;
namespace study.Strategies.Concrete.Interface
{
	public interface IStrategy
	{
        IEnumerable<string> PerformAlgorithm(List<string> list);
    }
}

