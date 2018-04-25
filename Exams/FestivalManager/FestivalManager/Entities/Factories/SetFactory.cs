using System;

using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;

    public class SetFactory : ISetFactory
    {
        public ISet CreateSet(string name, string type)
        {
            Type model = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid Set");
            }

            var isAssignable = typeof(ISet).IsAssignableFrom(model);

            if (!isAssignable)
            {
                throw new InvalidOperationException("This is not a set");
            }

            return (ISet)Activator.CreateInstance(model, name);
        }
    }
}
