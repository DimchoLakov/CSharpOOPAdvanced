using System;
using Logger.Interfaces;
using Logger.Models;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            ILayout iLayout = null;

            switch (layoutType)
            {
                case "SimpleLayout":
                    iLayout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    iLayout = new XmlLayout();
                    break;
                case "JsonLayout":
                    iLayout = new JsonLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid Layout Type!");

            }

            return iLayout;
        }
    }
}
