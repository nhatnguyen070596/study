using System;
using study.Repositories.Interface;
using study.Strategies.Concrete.Interface;

namespace study.Strategies.Concrete
{
	public class AlternativeConcreteStrategy : IStrategy
	{
		public AlternativeConcreteStrategy()
		{
		}

        public IEnumerable<string> PerformAlgorithm(List<string> list)
        {
            list.Sort();
            return list;
        }
    }
}

