using System;
using study.Repositories.Interface;
using study.Strategies.Concrete.Interface;

namespace study.Strategies.Concrete
{
	public class DefaultConcreteStrategy : IStrategy
	{
		public DefaultConcreteStrategy()
		{
		}
        public IEnumerable<string> PerformAlgorithm(List<string> list)
        {
            list.Sort();
            list.Reverse();
            return list;
        }
    }
}

