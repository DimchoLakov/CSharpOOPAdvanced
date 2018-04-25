using System;
using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            var model = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (model == null)
            {
                throw new ArgumentException("Invalid Instrument!");
            }

            var isAssignable = typeof(IInstrument).IsAssignableFrom(model);

            if (!isAssignable)
            {
                throw new InvalidOperationException("This is not an Instrument!");
            }

            return (IInstrument)Activator.CreateInstance(model);
        }
    }
}