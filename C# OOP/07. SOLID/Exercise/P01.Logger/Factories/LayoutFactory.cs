using P01.Logger.Models.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace P01.Logger.Factories
{
    public class LayoutFactory
    {
        public LayoutFactory()
        {

        }

        public ILayout CreateLayout(string layoutTypeStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type layoutType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(layoutTypeStr,
                StringComparison.InvariantCultureIgnoreCase));

            if (layoutType == null)
            {
                
            }

            object[] ctorArgs = new object[] { };

            ILayout layout = (ILayout)Activator.CreateInstance(layoutType, ctorArgs);

            return layout;
        }
    }
}
